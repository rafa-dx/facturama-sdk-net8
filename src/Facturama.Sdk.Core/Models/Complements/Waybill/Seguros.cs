using System.Text.Json.Serialization;

namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Seguros
    {
        [JsonPropertyName("AseguraRespCivil")]
        public string AseguraRespCivil { get; init; }

        [JsonPropertyName("PolizaRespCivil")]
        public string PolizaRespCivil { get; init; }

        [JsonPropertyName("AseguraMedAmbiente")]
        public string AseguraMedAmbiente { get; init; }

        [JsonPropertyName("PolizaMedAmbiente")]
        public string PolizaMedAmbiente { get; init; }

        [JsonPropertyName("AseguraCarga")]
        public string AseguraCarga { get; init; }

        [JsonPropertyName("PolizaCarga")]
        public string PolizaCarga { get; init; }

        [JsonPropertyName("PrimaSeguro")]
        public decimal PrimaSeguro { get; init; }
    }
}
