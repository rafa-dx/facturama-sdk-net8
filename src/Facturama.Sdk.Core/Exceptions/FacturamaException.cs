using System.Net;


namespace Facturama.Sdk.Core.Exceptions
{
    public class FacturamaException : Exception
    {
        /// <summary>
        /// Código de estado HTTP asociado al error.
        /// </summary>
        public HttpStatusCode? StatusCode { get; set; }

        public string? ResponseContent { get; set; }    

        public string? ErrorCode { get; set; }

        public FacturamaException(string message) :base (message)
        { }

        public FacturamaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FacturamaException(
            string message,
            string? responseContent = null,
            HttpStatusCode? statusCode = null,
            string? errorCode = null) 
            : base (message)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
            ErrorCode = errorCode;
        }

        public FacturamaException(
            string message,
            string? responseContent,
            Exception innerException,
            HttpStatusCode? statusCode = null,
            string? errorCode = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
            ErrorCode = errorCode;
        }

    }
}
