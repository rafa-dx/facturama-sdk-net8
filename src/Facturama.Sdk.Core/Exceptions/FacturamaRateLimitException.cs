using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace facturama-sdk-net8.src.facturama.Sdk.Core.Exceptions
{
    /// <summary>
    /// Excepción lanzada cuando se excede el límite de requests (HTTP 429).
    /// Espera antes de reintentar la petición.
    /// </summary>
    public class FacturamaRateLimitException : FacturamaException
    {
        /// <summary>
        /// Tiempo recomendado de espera antes de reintentar (en segundos).
        /// </summary>
        public int? RetryAfterSeconds { get; }

        public FacturamaRateLimitException(string message) : base(message)
        {
        }

        public FacturamaRateLimitException(
        string message,
        string? responseContent,
        int? retryAfterSeconds = null)
        : base(message, responseContent, HttpStatusCode.TooManyRequests)
        {
            RetryAfterSeconds = retryAfterSeconds;
        }
    }
}
