using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturama-sdk-net8.src.facturama.Sdk.Core.Exceptions
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
