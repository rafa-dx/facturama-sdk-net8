using Facturama.Sdk.Configuration;
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Infrastructure.Authentication;
using Facturama.Sdk.Infrastructure.Http;
using Facturama.Sdk.Services;
using FacturamaAPI.src.Facturama.Sdk.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace Facturama.Sdk.DependencyInjection;

/// <summary>
/// Métodos de extensión para configurar el SDK de Facturama en el contenedor de DI.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Agrega los servicios de Facturama al contenedor de DI usando IConfiguration.
    /// </summary>
    public static IServiceCollection AddFacturama(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<FacturamaOptions>(configuration.GetSection("Facturama"));
        services.AddSingleton<IValidateOptions<FacturamaOptions>, FacturamaOptionsValidator>();

        RegisterCoreServices(services);

        return services;
    }


    /// <summary>
    /// Agrega los servicios de Facturama al contenedor de DI.
    /// </summary>
    public static IServiceCollection AddFacturama(
        this IServiceCollection services,
        Action<FacturamaOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configure);

        services.Configure(configure);
        services.AddSingleton<IValidateOptions<FacturamaOptions>, FacturamaOptionsValidator>();

        RegisterCoreServices(services);

        return services;
    }


    private static void RegisterCoreServices(IServiceCollection services)
    {
        // Registrar AuthenticationHeaderHandler
        services.AddTransient<AuthenticationHeaderHandler>();

        // API Web
        services.AddHttpClient<IApiWebHttpClient, ApiWebHttpClient>("FacturamaApiWeb",
             (sp, client) => ConfigureHttpClient(sp, client, apiLite: false))
             .ConfigurePrimaryHttpMessageHandler(sp => ConfigureHttpHandler(sp))
             .AddHttpMessageHandler<AuthenticationHeaderHandler>()
             .AddPolicyHandler((sp, _) => GetRetryPolicy(sp))
             .AddPolicyHandler((sp, _) => GetCircuitBreakerPolicy(sp));


        // API LITE
        services.AddHttpClient<IApiLiteHttpClient, ApiLiteHttpClient>("FacturamaApiLite",
              (sp, client) => ConfigureHttpClient(sp, client, apiLite: true)) 
              .ConfigurePrimaryHttpMessageHandler(sp => ConfigureHttpHandler(sp))
              .AddHttpMessageHandler<AuthenticationHeaderHandler>()
              .AddPolicyHandler((sp, _) => GetRetryPolicy(sp))
              .AddPolicyHandler((sp, _) => GetCircuitBreakerPolicy(sp));

        //Retention
        services.AddHttpClient<IApiRetentionHttpClient, ApiRetentionHttpClient>("FacturamaRetention",
            (sp, client) => ConfigureHttpClient(sp, client, apiLite : false))
            .ConfigurePrimaryHttpMessageHandler(sp => ConfigureHttpHandler(sp))
            .AddHttpMessageHandler<AuthenticationHeaderHandler>()
              .AddPolicyHandler((sp, _) => GetRetryPolicy(sp))
              .AddPolicyHandler((sp, _) => GetCircuitBreakerPolicy(sp));


        // Registrar servicios individuales
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBranchOfficeService, BranchOfficeService>();
        services.AddScoped<ISeriesService, SerieService>();
        services.AddScoped<ISuscriptionPlanService, SuscriptionPlanService>();
        services.AddScoped<ICatalogService, CatalogService>();


        // Servicios CFDI
        services.AddScoped<ICfdiService, CfdiService>();
        services.AddScoped<ICfdiLiteService, CfdiLiteService>();

        //Retenciones
        services.AddScoped<IRetentionService, RetentionService>();

        // Cliente principal
        services.AddScoped<IFacturamaClient, FacturamaClient>();
    }


    /// <summary>
    /// Configura el HttpClient común para todas las APIs.
    /// </summary>
    private static void ConfigureHttpClient(
            IServiceProvider serviceProvider,
            HttpClient client,
            bool apiLite)
    {
        var options = serviceProvider.GetRequiredService<IOptions<FacturamaOptions>>().Value;
        var httpConfig = options.HttpClient;

        // BaseAddress según tipo de API — sin sobreescribir después
        client.BaseAddress = apiLite
            ? new Uri($"{options.BaseUrl}/api-lite/")
            : new Uri($"{options.BaseUrl}/api/");

        // Timeout
        client.Timeout = httpConfig.Timeout;

        // Headers comunes
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.UserAgent.Clear();

        // ── UserAgent ─────────────────────────────────────────────
        // httpConfig.UserAgent viene de SdkVersion: "FacturamaNet8-Sdk/1.0.0"
        // Resultado final: "FacturamaNet8-Sdk-{usuario}/1.0.0"
        var uaParts = httpConfig.UserAgent.Split('/', 2);
        var productName = $"{options.Username}-{uaParts[0]}";   // FacturamaNet8-Sdk-usuario
        var productVersion = uaParts.Length > 1 ? uaParts[1] : SdkVersion;

        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.UserAgent.Add(
            new ProductInfoHeaderValue(productName, productVersion));


        // Compresión
        if (httpConfig.EnableCompression)
        {
            client.DefaultRequestHeaders.AcceptEncoding.Add(
                new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(
                new StringWithQualityHeaderValue("deflate"));
        }

        // Headers personalizados
        if (httpConfig.CustomHeaders != null)
        {
            foreach (var header in httpConfig.CustomHeaders)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }


    }


    private static readonly string SdkVersion =
        typeof(ServiceCollectionExtensions).Assembly
            .GetName().Version?
            .ToString(3)   
        ?? "1.0.0";

    /// <summary>
    /// Configura el HttpClientHandler.
    /// </summary>
    private static HttpClientHandler ConfigureHttpHandler(
        IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<IOptions<FacturamaOptions>>().Value;
        var httpConfig = options.HttpClient;

        return new HttpClientHandler
        {
            MaxConnectionsPerServer = httpConfig.MaxConnectionsPerServer,
            AllowAutoRedirect = httpConfig.AllowAutoRedirect,
            MaxAutomaticRedirections = httpConfig.MaxAutomaticRedirections,
            AutomaticDecompression = httpConfig.EnableCompression
                ? System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                : System.Net.DecompressionMethods.None
        };
    }

    /// <summary>
    /// Obtiene la política de reintentos configurada.
    /// </summary>
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(
        IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<IOptions<FacturamaOptions>>().Value;
        var retryConfig = options.RetryPolicy;

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => retryConfig.RetryOnStatusCodes.Contains((int)msg.StatusCode))
            .WaitAndRetryAsync(
                retryCount: retryConfig.MaxRetries,
                sleepDurationProvider: retryAttempt =>
                    retryConfig.CalculateDelay(retryAttempt),
                onRetry: (outcome, timespan, retryCount, context) =>
                {
                    var logger = serviceProvider.GetService<ILogger<FacturamaClient>>();
                    logger?.LogWarning(
                        "Request failed with {StatusCode}. Waiting {Delay}ms before retry {RetryCount}/{MaxRetries}",
                        outcome.Result?.StatusCode,
                        timespan.TotalMilliseconds,
                        retryCount,
                        retryConfig.MaxRetries);
                });
    }

    /// <summary>
    /// Obtiene la política de circuit breaker.
    /// </summary>
    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(
        IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<IOptions<FacturamaOptions>>().Value;
        var cbConfig = options.CircuitBreaker;

        if (!cbConfig.Enabled)
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: cbConfig.FailuresBeforeBreaking,
                durationOfBreak: cbConfig.DurationOfBreak,
                onBreak: (outcome, duration) =>
                {
                    var logger = serviceProvider.GetService<ILogger<FacturamaClient>>();
                    logger?.LogError(
                        "Circuit breaker opened for {Duration}s after {Failures} consecutive failures",
                        duration.TotalSeconds,
                        cbConfig.FailuresBeforeBreaking);
                },
                onReset: () =>
                {
                    var logger = serviceProvider.GetService<ILogger<FacturamaClient>>();
                    logger?.LogInformation("Circuit breaker reset - connection restored");
                });
    }


}