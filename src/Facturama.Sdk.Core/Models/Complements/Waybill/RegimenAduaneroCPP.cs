using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record RegimenAduaneroCPP
    {
        [JsonPropertyName("RegimenAduanero")]
        public string RegimenAduanero { get; init; }
    }
}
