using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Common
{
    public sealed record Tax
    {
        [JsonPropertyName("Total")]
        public decimal Total { get; init; }

        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("Base")]
        public decimal Base { get; init; }

        [JsonPropertyName("Rate")]
        public decimal Rate { get; init; }

        [JsonPropertyName("IsRetention")]
        public bool IsRetention { get; init; }

        [JsonPropertyName("IsQuota")]
        public bool IsQuota { get; init; }
    }
}
