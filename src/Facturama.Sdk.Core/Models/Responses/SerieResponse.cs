using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Responses
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
