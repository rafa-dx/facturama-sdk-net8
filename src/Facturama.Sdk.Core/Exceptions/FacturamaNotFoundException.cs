using System.Net;


namespace Facturama.Sdk.Core.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando el recurso solicitado no existe (HTTP 404).
    /// </summary>
    public class FacturamaNotFoundException : FacturamaException
    {
        /// <summary>
        /// ID del recurso que no se encontró.
        /// </summary>
        public string? ResourceId { get; set; }

        /// <summary>
        /// Tipo de recurso que no se encontró (ej: "Client", "Product", "Cfdi").
        /// </summary>
        public string? ResourceType { get; set; }

        public FacturamaNotFoundException(string message) : base(message)
        {
        }

        public FacturamaNotFoundException(
            string message,
            string? responseContent) : base(message, responseContent)
        {

        }

        public FacturamaNotFoundException(
        string resourceType,
        string resourceId,
        string? responseContent = null)
        : base($"{resourceType} with ID '{resourceId}' was not found", responseContent, HttpStatusCode.NotFound)
        {
            ResourceType = resourceType;
            ResourceId = resourceId;
        }
    }
}
