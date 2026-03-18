using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record CfdiStatusResponse
    {
        public string Status { get; init; }
        public string IsCancelable { get; init; }
        public string Uuid { get; init; }
    }
}
