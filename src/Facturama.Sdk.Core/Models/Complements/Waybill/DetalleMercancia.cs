using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
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
