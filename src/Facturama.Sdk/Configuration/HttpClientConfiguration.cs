namespace Facturama.Sdk.Configuration
{

    /// <summary>
    /// Configuración del cliente HTTP para las peticiones a la API de Facturama.
    /// </summary>
    public sealed class HttpClientConfiguration
    {
        /// <summary>
        /// Timeout para las peticiones HTTP.
        /// Default: 30 segundos.
        /// </summary>
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// User-Agent enviado en las peticiones.
        /// Default: "FacturamaSDK/1.0.0".
        /// </summary>
        public string UserAgent { get; set; } = SdkVersion.UserAgent;
        /// <summary>
        /// Habilita compresión de contenido (gzip, deflate).
        /// Default: true.
        /// </summary>
        public bool EnableCompression { get; set; } = true;

        /// <summary>
        /// Número máximo de conexiones concurrentes por servidor.
        /// Default: 10.
        /// </summary>
        public int MaxConnectionsPerServer { get; set; } = 10;

        /// <summary>
        /// Headers personalizados adicionales para todas las peticiones.
        /// Útil para agregar headers corporativos o de tracking.
        /// </summary>
        public Dictionary<string, string>? CustomHeaders { get; set; }

        /// <summary>
        /// Habilita el seguimiento automático de redirecciones HTTP.
        /// Default: true.
        /// </summary>
        public bool AllowAutoRedirect { get; set; } = true;

        /// <summary>
        /// Número máximo de redirecciones automáticas permitidas.
        /// Default: 3.
        /// </summary>
        public int MaxAutomaticRedirections { get; set; } = 3;

        /// <summary>
        /// Valida que la configuración sea correcta.
        /// </summary>
        public void Validate()
        {
            if (Timeout <= TimeSpan.Zero)
            {
                throw new ArgumentException(
                    "Timeout debe ser mayor a cero.",
                    nameof(Timeout));
            }

            if (Timeout > TimeSpan.FromMinutes(5))
            {
                throw new ArgumentException(
                    "Timeout no puede ser mayor a 5 minutos.",
                    nameof(Timeout));
            }

            if (string.IsNullOrWhiteSpace(UserAgent))
            {
                throw new ArgumentException(
                    "UserAgent no puede estar vacío.",
                    nameof(UserAgent));
            }

            if (MaxConnectionsPerServer < 1)
            {
                throw new ArgumentException(
                    "MaxConnectionsPerServer debe ser al menos 1.",
                    nameof(MaxConnectionsPerServer));
            }

            if (MaxConnectionsPerServer > 100)
            {
                throw new ArgumentException(
                    "MaxConnectionsPerServer no puede ser mayor a 100.",
                    nameof(MaxConnectionsPerServer));
            }

            if (MaxAutomaticRedirections < 0)
            {
                throw new ArgumentException(
                    "MaxAutomaticRedirections no puede ser negativo.",
                    nameof(MaxAutomaticRedirections));
            }
        }

    }
}
