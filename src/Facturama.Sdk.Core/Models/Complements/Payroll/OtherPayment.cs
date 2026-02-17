using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
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
