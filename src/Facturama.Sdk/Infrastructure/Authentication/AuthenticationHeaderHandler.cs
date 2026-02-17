using Facturama.Sdk.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;


namespace Facturama.Sdk.Infrastructure.Authentication;

/// <summary>
/// Handler HTTP que agrega automáticamente el header de autenticación Basic a cada petición.
/// </summary>
internal sealed class AuthenticationHeaderHandler : DelegatingHandler
{
    private readonly string _encodedCredentials;
    private readonly ILogger<AuthenticationHeaderHandler> _logger;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="AuthenticationHeaderHandler"/>.
    /// </summary>
    /// <param name="options">Opciones de configuración de Facturama.</param>
    /// <param name="logger">Logger para diagnósticos.</param>
    /// <exception cref="ArgumentNullException">
    /// Se lanza cuando options o logger son null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Se lanza cuando Username o Password están vacíos.
    /// </exception>
    public AuthenticationHeaderHandler(
        IOptions<FacturamaOptions> options,
        ILogger<AuthenticationHeaderHandler> logger)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;

        var facturamaOptions = options.Value;

        // Validar credenciales
        if (string.IsNullOrWhiteSpace(facturamaOptions.Username))
        {
            throw new ArgumentException(
                "El Username no puede estar vacío.",
                nameof(options));
        }

        if (string.IsNullOrWhiteSpace(facturamaOptions.Password))
        {
            throw new ArgumentException(
                "El Password no puede estar vacío.",
                nameof(options));
        }

        // Calcular credenciales codificadas UNA SOLA VEZ
        // Formato: "username:password" → Base64
        var credentials = $"{facturamaOptions.Username}:{facturamaOptions.Password}";
        _encodedCredentials = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(credentials));

        _logger.LogDebug(
            "AuthenticationHeaderHandler inicializado para usuario: {Username}",
            facturamaOptions.Username);
    }

    /// <summary>
    /// Envía una petición HTTP después de agregar el header de autenticación.
    /// </summary>
    /// <param name="request">Petición HTTP a enviar.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>Respuesta HTTP.</returns>
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        // Agregar header de autenticación Basic
        // Authorization: Basic {base64_credentials}
        request.Headers.Authorization = new AuthenticationHeaderValue(
            "Basic",
            _encodedCredentials);

        _logger.LogTrace(
            "Header de autenticación agregado a {Method} {Uri}",
            request.Method,
            request.RequestUri);

        // Continuar con el siguiente handler en el pipeline
        return await base.SendAsync(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Libera los recursos del handler.
    /// </summary>
    /// <param name="disposing">Indica si se debe liberar recursos administrados.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _logger.LogDebug("AuthenticationHeaderHandler disposed");
        }

        base.Dispose(disposing);
    }
}

// Notas de implementación:
//
// 1. Thread-Safety:
//    - Este handler es registrado como Singleton en DI
//    - Solo usa campos readonly → Thread-safe
//    - No mantiene estado mutable entre peticiones
//
// 2. Performance:
//    - La codificación Base64 se calcula UNA SOLA VEZ en el constructor
//    - NO se recalcula en cada petición (esto sería ineficiente)
//    - El string _encodedCredentials se reutiliza para todas las peticiones
//
// 3. Seguridad:
//    - Las credenciales nunca se loguean (solo el username)
//    - El password nunca aparece en logs
//    - La codificación Base64 NO es encriptación (es solo encoding)
//    - Basic Auth envía credenciales en cada request
//    - SIEMPRE usar HTTPS en producción
//
// 4. Pipeline:
//    - Este handler se ejecuta ANTES de enviar la petición al servidor
//    - Se registra en el pipeline del HttpClient en ServiceCollectionExtensions
//    - Order: HttpClient → AuthenticationHeaderHandler → Network
//
// 5. Uso en DI (cómo se registrará):
//    services.AddHttpClient<IFacturamaClient, FacturamaClient>(client =>
//    {
//        client.BaseAddress = new Uri(options.BaseUrl);
//        client.Timeout = options.Timeout;
//    })
//    .AddHttpMessageHandler<AuthenticationHeaderHandler>();
//
// 6. Testing:
//    - Puede mockearse fácilmente
//    - Inyectar IOptions<FacturamaOptions> con valores de prueba
//    - Verificar que el header Authorization se agrega correctamente