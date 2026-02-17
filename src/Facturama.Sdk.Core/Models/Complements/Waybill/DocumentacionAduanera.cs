using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record DocumentacionAduanera
    {
        [JsonPropertyName("TipoDocumento")]
        public string TipoDocumento { get; init; }

        [JsonPropertyName("NumPedimento")]
        public string NumPedimento { get; init; }

        [JsonPropertyName("IdentDocAduanero")]
        public string IdentDocAduanero { get; init; }

        [JsonPropertyName("RFCImpo")]
        public string RFCImpo { get; init; }
    }
}
