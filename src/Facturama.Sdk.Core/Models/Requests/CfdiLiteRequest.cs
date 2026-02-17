using FacturamaAPI.src.Facturama.Sdk.Core.Models.Cfdi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Request
{
    public sealed record CfdiLiteRequest : CfdiBase
    {
        public string LogoUrl { get; init; }

        public Issuer Issuer { get; init; } = default!;


    }
}
