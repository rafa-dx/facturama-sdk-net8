using Facturama.Sdk.Configuration;
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Infrastructure.Authentication;
using Facturama.Sdk.Infrastructure.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace Facturama.Sdk.DependencyInjection;

/// <summary>
/// Métodos de extensión para configurar el SDK de Facturama en el contenedor de DI.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Agrega los servicios de Facturama al contenedor de DI.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <param name="configure">Acción para configurar las opciones de Facturama.</param>
    /// <returns>La colección de servicios para encadenamiento.</returns>
    /// <example>
    /// <code>
    /// services.AddFacturama(options =>
    /// {
    ///     options.Username = "usuario";
    ///     options.Password = "contraseña";
    ///     options.Environment = FacturamaEnvironment.Sandbox;
    /// });
    /// </code>
    /// </example>
    public static IServiceCollection AddFacturama(
        this IServiceCollection services,
        Action<FacturamaOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configure);

        // Configurar opciones
        services.Configure(configure);

        // Registrar validador de opciones
        services.AddSingleton<IValidateOptions<FacturamaOptions>, FacturamaOptionsValidator>();

        // Registrar servicios core
        RegisterCoreServices(services);

        return services;
    }

    /// <summary>
    /// Agrega los servicios de Facturama al contenedor de DI usando IConfiguration.
    /// </summary>
    /// <param name="services">Colección de servicios.</param>
    /// <param name="configuration">Configuración desde appsettings.json.</param>
    /// <param name="sectionName">Nombre de la sección de configuración (default: "Facturama").</param>
    /// <returns>La colección de servicios para encadenamiento.</returns>
    /// <example>
    /// <code>
    /// // appsettings.json:
    /// // {
    /// //   "Facturama": {
    /// //     "Username": "usuario",
    /// //     "Password": "contraseña",
    /// //     "Environment": "Sandbox"
    /// //   }
    /// // }
    /// 
    /// services.AddFacturama(configuration);
    /// </code>
    /// </example>
    public static IServiceCollection AddFacturama(
        this IServiceCollection services,
        IConfiguration configuration,
        string sectionName = "Facturama")
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentException.ThrowIfNullOrWhiteSpace(sectionName);

        // Configurar desde appsettings
        services.Configure<FacturamaOptions>(
            configuration.GetSection(sectionName));

        // Registrar validador de opciones
        services.AddSingleton<IValidateOptions<FacturamaOptions>, FacturamaOptionsValidator>();

        // Registrar servicios core
        RegisterCoreServices(services);

        return services;
    }

    /// <summary>
    /// Registra los servicios principales del SDK.
    /// </summary>
    private static void RegisterCoreServices(IServiceCollection services)
    {
        // Registrar AuthenticationHeaderHandler como Transient
        // (se crea una instancia por cada HttpClient)
        services.AddTransient<AuthenticationHeaderHandler>();

        // Configurar HttpClient con nombre "Facturama"
        services.AddHttpClient<IFacturamaHttpClient, FacturamaHttpClient>("Facturama",
            (serviceProvider, client) =>
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<FacturamaOptions>>()
                    .Value;

                var httpConfig = options.HttpClient;

                // Configurar BaseAddress
                client.BaseAddress = new Uri(options.BaseUrl);

                // Configurar Timeout
                client.Timeout = httpConfig.Timeout;

                // Headers comunes
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.Clear();
                client.DefaultRequestHeaders.UserAgent.Add(
                    new ProductInfoHeaderValue(
                        httpConfig.UserAgent.Split('/')[0],  
                        httpConfig.UserAgent.Split('/').Length > 1
                            ? httpConfig.UserAgent.Split('/')[1]
                            : "1.0.0"
                    ));

                // Habilitar compresión si está configurado
                if (httpConfig.EnableCompression)
                {
                    client.DefaultRequestHeaders.AcceptEncoding.Add(
                        new StringWithQualityHeaderValue("gzip"));
                    client.DefaultRequestHeaders.AcceptEncoding.Add(
                        new StringWithQualityHeaderValue("deflate"));
                }


                // Headers personalizados
                if (httpConfig.CustomHeaders != null) // ← NUEVO
                {
                    foreach (var header in httpConfig.CustomHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

            })
            .ConfigurePrimaryHttpMessageHandler((serviceProvider) => // ← NUEVO
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<FacturamaOptions>>()
                    .Value;

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
            })
            // Agregar handler de autenticación
            .AddHttpMessageHandler<AuthenticationHeaderHandler>()
            // Agregar políticas de resiliencia con Polly
            .AddPolicyHandler((serviceProvider, request) =>
                GetRetryPolicy(serviceProvider))
            .AddPolicyHandler((serviceProvider, request) =>
                GetCircuitBreakerPolicy(serviceProvider));

        // Registrar IFacturamaClient
        services.AddScoped<IFacturamaClient, FacturamaClient>();
    }

    /// <summary>
    /// Obtiene la política de reintentos configurada.
    /// </summary>
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(
        IServiceProvider serviceProvider)
    {
        var options = serviceProvider
            .GetRequiredService<IOptions<FacturamaOptions>>()
            .Value;

        var retryConfig = options.RetryPolicy;

        return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => retryConfig.RetryOnStatusCodes.Contains((int)msg.StatusCode)) // ← CAMBIADO
        .WaitAndRetryAsync(
            retryCount: retryConfig.MaxRetries, // ← CAMBIADO
            sleepDurationProvider: retryAttempt =>
                retryConfig.CalculateDelay(retryAttempt), // ← CAMBIADO
            onRetry: (outcome, timespan, retryCount, context) =>
            {
                var logger = serviceProvider
                    .GetService<Microsoft.Extensions.Logging.ILogger<FacturamaClient>>();

                logger?.LogWarning(
                    "Request failed with {StatusCode}. Waiting {Delay}ms before retry {RetryCount}/{MaxRetries}",
                    outcome.Result?.StatusCode,
                    timespan.TotalMilliseconds,
                    retryCount,
                    retryConfig.MaxRetries); // ← CAMBIADO
            });
    }

    /// <summary>
    /// Obtiene la política de circuit breaker.
    /// </summary>
    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy(
        IServiceProvider serviceProvider)
    {
        var options = serviceProvider
            .GetRequiredService<IOptions<FacturamaOptions>>()
            .Value;

        var cbConfig = options.CircuitBreaker; // ← NUEVO

        if (!cbConfig.Enabled) // ← NUEVO
        {
            return Policy.NoOpAsync<HttpResponseMessage>();
        }

        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: cbConfig.FailuresBeforeBreaking, // ← CAMBIADO
                durationOfBreak: cbConfig.DurationOfBreak, // ← CAMBIADO
                onBreak: (outcome, duration) =>
                {
                    var logger = serviceProvider
                        .GetService<Microsoft.Extensions.Logging.ILogger<FacturamaClient>>();

                    logger?.LogError(
                        "Circuit breaker opened for {Duration}s after {Failures} consecutive failures",
                        duration.TotalSeconds,
                        cbConfig.FailuresBeforeBreaking); // ← CAMBIADO
                },
                onReset: () =>
                {
                    var logger = serviceProvider
                        .GetService<Microsoft.Extensions.Logging.ILogger<FacturamaClient>>();

                    logger?.LogInformation("Circuit breaker reset - connection restored");
                });
    }
}