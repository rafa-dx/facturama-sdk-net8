using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace facturama-sdk-net8.src.facturama.Sdk.Core.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando hay un error en el servidor de Facturama (HTTP 500+).
    /// Este error generalmente es temporal. Considera implementar reintentos.
    /// </summary>
    public class FacturamaServerException : FacturamaException
    {
        public FacturamaServerException(string message)
        : base(message)
        {
        }

        public FacturamaServerException(
            string message,
            string? responseContent,
            HttpStatusCode? statusCode = null)
            : base(message, responseContent, statusCode)
        {
        }

        public FacturamaServerException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
