using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record DetalleMercancia
    {

        [JsonPropertyName("UnidadPesoMerc")]
        public string UnidadPesoMerc { get; init; }

        [JsonPropertyName("PesoBruto")]
        public decimal PesoBruto { get; init; }

        [JsonPropertyName("PesoNeto")]
        public decimal PesoNeto { get; init; }

        [JsonPropertyName("PesoTara")]
        public decimal PesoTara { get; init; }

        [JsonPropertyName("NumPiezas")]
        public int NumPiezas { get; init; }
    }
}
