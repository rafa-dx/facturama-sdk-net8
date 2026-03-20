using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record SerieRequest
    {
        [JsonPropertyName("IdBranchOffice")]
        public string IdBranchOffice { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Folio")]
        public long Folio { get; set; }
    }
}
