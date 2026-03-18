using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record CfdiSendResponse
    {
        public string Msj { get; init; }
        public bool Success { get; init; }
    }
}
