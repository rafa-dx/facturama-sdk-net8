using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace facturama-sdk-net8.src.facturama.Sdk.Core.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando los datos enviados no son válidos (HTTP 400).
    /// Revisa los campos requeridos y sus formatos.
    /// </summary>
    public class FacturamaValidationException : FacturamaException
    {
        public IReadOnlyList<ValidationError>? ValidationErrors { get; init; }
        public FacturamaValidationException(string message) : base(message)
        {
            ValidationErrors = Array.Empty<ValidationError>();
        }


        public FacturamaValidationException(
            string message, 
            string? responseContent) 
            : base(message, responseContent, HttpStatusCode.BadRequest)
        {
            ValidationErrors = ParseValidationErrors(responseContent);
        }

        public FacturamaValidationException(
        IReadOnlyList<ValidationError> validationErrors)
        : base("Validation failed")
        {
            ValidationErrors = validationErrors ?? Array.Empty<ValidationError>();
        }

        private static IReadOnlyList<ValidationError> ParseValidationErrors(string? content)
        {
            // TODO: Implementar parsing del formato de error de Facturama
            // Por ahora retorna vacío, se implementará cuando sepamos el formato exacto
            return Array.Empty<ValidationError>();
        }
    }
    /// <summary>
    /// Representa un error de validación específico.
    /// </summary>
    public record ValidationError(
        string Field,
        string Message,
        string? Code = null
    );
}
