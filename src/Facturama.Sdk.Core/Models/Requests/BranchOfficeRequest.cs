using Facturama.Sdk.Core.Models.Common;

using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record BranchOfficeRequest
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Address")]
        public Address Address { get; set; }

    }
}
