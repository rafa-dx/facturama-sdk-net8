using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Compensation
    {
        [JsonPropertyName("PositiveBalance")]
        public decimal PositiveBalance { get; init; }

        [JsonPropertyName("Year")]
        public short Year { get; init; }

        [JsonPropertyName("RemainingPositiveBalance")]
        public decimal RemainingPositiveBalance { get; init; }
    }
}
