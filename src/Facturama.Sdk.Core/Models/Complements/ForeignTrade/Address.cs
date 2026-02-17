using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.ForeignTrade
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

        [JsonPropertyName("Reference")]
        public string Reference { get; init; }

        [JsonPropertyName("Locality")]
        public string Locality { get; init; }

        [JsonPropertyName("Municipality")]
        public string Municipality { get; init; }

        [JsonPropertyName("State")]
        public string State { get; init; }

        [JsonPropertyName("Country")]
        public string Country { get; init; }

        [JsonPropertyName("ZipCode")]
        public string ZipCode { get; init; }
    }
}
