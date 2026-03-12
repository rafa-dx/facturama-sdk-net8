using Facturama.Sdk.Core.Models.Common;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record SerieResponse : CatalogBase
    {
        [JsonPropertyName("IdBranchOffice")]
        public string IdBranchOffice { get; init; }


        [JsonPropertyName("Folio")]
        public long Folio { get; init; }
    }
}
