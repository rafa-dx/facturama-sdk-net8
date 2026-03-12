using Facturama.Sdk.Core.Models.Common;

using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record BranchOfficeResponse
    {
        [JsonPropertyName("Id")]
        public string Id { get; init; }

        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("Address")]
        public Address Address { get; init; }

        [JsonPropertyName("IdDefault")]
        public string IsDefault { get; init; }

    }
}
