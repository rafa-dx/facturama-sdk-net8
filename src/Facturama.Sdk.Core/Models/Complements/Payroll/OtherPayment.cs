using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record OtherPayment
    {
        [JsonPropertyName("EmploymentSubsidy")]
        public EmploymentSubsidy EmploymentSubsidy { get; init; }

        [JsonPropertyName("Compensation")]
        public Compensation Compensation { get; init; }

        [JsonPropertyName("OtherPaymentType")]
        public string OtherPaymentType { get; init; }

        [JsonPropertyName("Code")]
        public string Code { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; init; }
    }
}
