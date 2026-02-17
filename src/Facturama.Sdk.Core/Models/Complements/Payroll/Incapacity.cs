using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Incapacity
    {

        [JsonPropertyName("Days")]
        public int Days { get; init; }

        [JsonPropertyName("Type")]
        public string Type { get; init; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; init; }
    }
}
