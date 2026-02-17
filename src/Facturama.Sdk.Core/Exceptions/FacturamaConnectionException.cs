namespace Facturama.Sdk.Core.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando hay problemas de conectividad con la API.
    /// Verifica tu conexión a internet y el estado del servicio de Facturama.
    /// </summary>
    public class FacturamaConnectionException : FacturamaException
    {
        public FacturamaConnectionException(string message)
        : base(message)
        {
        }

        public FacturamaConnectionException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
