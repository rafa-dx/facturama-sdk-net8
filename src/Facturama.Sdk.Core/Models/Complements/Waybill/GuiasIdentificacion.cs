using System.Text.Json.Serialization;

namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record GuiasIdentificacion
    {
        [JsonPropertyName("NumeroGuiaIdentificacion")]
        public string NumeroGuiaIdentificacion { get; set; }

        [JsonPropertyName("DescripGuiaIdentificacion")]
        public string DescripGuiaIdentificacion { get; set; }

        [JsonPropertyName("PesoGuiaIdentificacion")]
        public decimal PesoGuiaIdentificacion { get; set; }
    }
}
