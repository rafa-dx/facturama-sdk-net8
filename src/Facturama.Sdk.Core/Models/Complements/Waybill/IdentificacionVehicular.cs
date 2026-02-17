using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record IdentificacionVehicular
    {
        [JsonPropertyName("ConfigVehicular")]
        public string ConfigVehicular { get; init; }
        [JsonPropertyName("PesoBrutoVehicular")]
        public string PesoBrutoVehicular { get; init; }

        [JsonPropertyName("PlacaVM")]
        public string PlacaVM { get; init; }

        [JsonPropertyName("AnioModeloVM")]
        public int AnioModeloVM { get; init; }
    }
}
