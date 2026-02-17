using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Autotransporte
    {
        [JsonPropertyName("PermSCT")]
        public string PermSCT { get; init; }

        [JsonPropertyName("NumPermisoSCT")]
        public string NumPermisoSCT { get; init; }

        [JsonPropertyName("Seguros")]
        public Seguros Seguros { get; init; }

        [JsonPropertyName("IdentificacionVehicular")]
        public IdentificacionVehicular IdentificacionVehicular { get; init; }

        [JsonPropertyName("Remolques")]
        public Remolque[] Remolques { get; init; }
    }
}
