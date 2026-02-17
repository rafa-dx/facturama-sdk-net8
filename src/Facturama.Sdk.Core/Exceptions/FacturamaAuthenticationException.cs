namespace Facturama.Sdk.Core.Exceptions
{
    public  class FacturamaAuthenticationException : FacturamaException
    {
        public FacturamaAuthenticationException(string message) : base(message)
        {
        }

        public FacturamaAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FacturamaAuthenticationException(string message, string? responseContent): base(message, responseContent) 
        {
        }
    }
}
