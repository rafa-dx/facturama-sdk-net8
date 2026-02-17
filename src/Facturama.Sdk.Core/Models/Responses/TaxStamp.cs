using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record TaxStamp
    {
        [JsonPropertyName("Uuid")]
        public string Uuid { get; init; }

        [JsonPropertyName("Date")]
        public string Date { get; init; }

        [JsonPropertyName("CfdiSign")]
        public string CfdiSign { get; init; }

        [JsonPropertyName("SatCertNumber")]
        public string SatCertNumber { get; init; }

        [JsonPropertyName("SatSign")]
        public string SatSign { get; init; }
    }
}
