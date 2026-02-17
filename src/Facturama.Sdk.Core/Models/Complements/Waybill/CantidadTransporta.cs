using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record CantidadTransporta
    {
        [JsonPropertyName("Cantidad")]
        public decimal Cantidad { get; init; }

        [JsonPropertyName("IDOrigen")]
        public string IDOrigen { get; init; }

        [JsonPropertyName("IDDestino")]
        public string IDDestino { get; init; }

        [JsonPropertyName("CvesTransporte")]
        public string CvesTransporte { get; init; }
    }
}
