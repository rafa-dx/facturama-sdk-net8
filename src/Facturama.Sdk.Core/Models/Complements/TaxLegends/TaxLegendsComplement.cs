using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.TaxLegends
{
    public sealed record TaxLegendsComplement
    {
        [JsonPropertyName("Legends")]
        public Legend[] Legends { get; init; }

    }
    public class Legend
    {
        [JsonPropertyName("TaxProvision")]
        public string TaxProvision { get; init; }

        [JsonPropertyName("Norm")]
        public string Norm { get; init; }

        [JsonPropertyName("Text")]
        public string Text { get; init; }
    }
}

