namespace Facturama.Sdk.Core.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando la petición excede el tiempo máximo configurado.
    /// Considera aumentar el timeout o verificar la conectividad.
    /// </summary>
    public class FacturamaTimeoutException : FacturamaException
    {
        /// <summary>
        /// Timeout configurado en segundos.
        /// </summary>
        public int TimeoutSeconds { get; }

        public FacturamaTimeoutException(int timeoutSeconds)
            : base($"The request timed out after {timeoutSeconds} seconds")
        {
            TimeoutSeconds = timeoutSeconds;
        }

        public FacturamaTimeoutException(
            int timeoutSeconds,
            Exception innerException)
            : base($"The request timed out after {timeoutSeconds} seconds", innerException)
        {
            TimeoutSeconds = timeoutSeconds;
        }
    }
}
