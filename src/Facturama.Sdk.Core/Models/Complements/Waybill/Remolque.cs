using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Remolque
    {
        [JsonPropertyName("SubTipoRem")]
        public string SubTipoRem { get; init; }


        [JsonPropertyName("Placa")]
        public string Placa { get; init; }
    }
}
