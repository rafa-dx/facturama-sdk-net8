using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Request
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
