using Facturama.Sdk.Core.Models.Common;

using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record BranchOfficeRequest
    {

        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("Address")]
        public Address Address { get; init; }

    }
}
