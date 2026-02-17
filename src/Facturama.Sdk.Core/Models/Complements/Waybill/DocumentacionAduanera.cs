
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
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
