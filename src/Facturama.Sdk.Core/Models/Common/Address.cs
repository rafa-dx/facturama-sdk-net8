using System.Text.Json.Serialization;

namespace src.Facturama.Sdk.Core.Models.Common
{
    public sealed record Address
    {

        [JsonPropertyName("Street")]
        public string Street { get; init; }

        [JsonPropertyName("ExteriorNumber")]
        public string ExteriorNumber { get; init; }

        [JsonPropertyName("InteriorNumber")]
        public string InteriorNumber { get; init; }

        [JsonPropertyName("Neighborhood")]
        public string Neighborhood { get; init; }

        [JsonPropertyName("ZipCode")]
        public string ZipCode { get; init; }

        [JsonPropertyName("Locality")]
        public string Locality { get; init; }

        [JsonPropertyName("Municipality")]
        public string Municipality { get; init; }

        [JsonPropertyName("State")]
        public string State { get; init; }

        [JsonPropertyName("Country")]
        public string Country { get; init; }
    }
}
