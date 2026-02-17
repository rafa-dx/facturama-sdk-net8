using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Outsourcing
    {

        [JsonPropertyName("RfcContractor")]
        public string RfcContractor { get; init; }

        [JsonPropertyName("PercentageTime")]
        public decimal PercentageTime { get; init; }
    }
}
