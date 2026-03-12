using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record CsdResponse
    {
        public string Rfc { get; init; }
        public string ExpirationDate { get; init; }
        public string Certificate {  get; init; }
        public string PrivateKey { get; init; }
        public string PrivateKeyPassword { get; init; }
    }
}
