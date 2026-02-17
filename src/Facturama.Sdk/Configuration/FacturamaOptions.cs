using Facturama.Sdk.Core.Enums;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace Facturama.Sdk.Configuration
{
    /// <summary>
    /// Opciones de configuración para el cliente de Facturama.
    /// </summary>
    public sealed class FacturamaOptions
    {
        /// <summary>
        /// Nombre de usuario para autenticación en la API de Facturama.
        /// </summary>
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña para autenticarse en la API de Facturama.
        ///  </summary>
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Ambiente de la API a utilziar /Sandbox o /Production.
        /// Default: Sandbox.
        /// </summary>
        public FacturamaEnvironment Environment { get; set; } = FacturamaEnvironment.Sandbox;

        /// <summary>
        /// Timeout para las solicitudes HTTP en segundos.
        /// Default: 30 segundos.
        ///  </summary>
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Numero maximo de reintentos para solicitudes fallidas.
        /// Default: 3 reintentos.
        /// </summary>  
        [Range(0, 10, ErrorMessage = "MaxRetries debe estar entre 0 y 10.")]
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// Habilita el logging de peticiones y respuestas.
        /// Default: true.
        /// </summary>
        public bool EnableLogging { get; set; } = true;

        /// <summary>
        /// Habilita compresión de contenido (gzip) en las peticiones.
        /// Default: true.
        /// </summary>
        public bool EnableCompression { get; set; } = true;

        /// <summary>
        /// Obtiene la URL base de la API según el ambiente configurado.
        /// </summary>
        public string BaseUrl => Environment.GetBaseUrl();

        /// <summary>
        /// Configuración del cliente HTTP.
        /// </summary>
        public HttpClientConfiguration HttpClient { get; set; } = new();

        /// <summary>
        /// Configuración de la política de reintentos.
        /// </summary>
        public RetryPolicyConfiguration RetryPolicy { get; set; } = new();

        /// <summary>
        /// Configuración del Circuit Breaker.
        /// </summary>
        public CircuitBreakerConfiguration CircuitBreaker { get; set; } = new();

        /// <summary>
        /// Valida que la configuración sea válida.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Se lanza cuando la configuración no es válida.
        /// </exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                throw new ValidationException("El Username es requerido y no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                throw new ValidationException("El Password es requerido y no puede estar vacío.");
            }

            if (Timeout <= TimeSpan.Zero)
            {
                throw new ValidationException("El Timeout debe ser mayor a cero.");
            }

            if (Timeout > TimeSpan.FromMinutes(5))
            {
                throw new ValidationException("El Timeout no puede ser mayor a 5 minutos.");
            }

            if (MaxRetries < 0)
            {
                throw new ValidationException("MaxRetries no puede ser negativo.");
            }

            if (MaxRetries > 10)
            {
                throw new ValidationException("MaxRetries no puede ser mayor a 10.");
            }

            if (!Enum.IsDefined(typeof(FacturamaEnvironment), Environment))
            {
                throw new ValidationException("El Environment especificado no es válido.");
            }
            HttpClient.Validate();
            RetryPolicy.Validate();
            CircuitBreaker.Validate();
        }
    }
    /// <summary>
    /// Validador para FacturamaOptions usando el patrón IValidateOptions.
    /// Se ejecuta automáticamente cuando se resuelve IOptions&lt;FacturamaOptions&gt; desde DI.
    /// </summary>
    public sealed class FacturamaOptionsValidator : IValidateOptions<FacturamaOptions>
    {
        public ValidateOptionsResult Validate(string? name, FacturamaOptions options)
        {
            try
            {
                options.Validate();
                return ValidateOptionsResult.Success;
            }
            catch (ValidationException ex)
            {
                return ValidateOptionsResult.Fail(ex.Message);
            }
        }
    }
}