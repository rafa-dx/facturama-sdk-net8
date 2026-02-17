using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record EmploymentSubsidy
    {
        [JsonPropertyName("Amount")]
        public decimal Amount { get; init; }
    }
}
