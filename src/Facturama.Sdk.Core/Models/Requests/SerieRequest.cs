using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record SerieRequest
    {
        [JsonPropertyName("IdBranchOffice")]
        public string IdBranchOffice { get; init; }
        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("Folio")]
        public long Folio { get; init; }
    }
}
