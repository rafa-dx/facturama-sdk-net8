using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class OtherPayment
    {
        [JsonPropertyName("EmploymentSubsidy")]
        public EmploymentSubsidy EmploymentSubsidy { get; set; }

        [JsonPropertyName("Compensation")]
        public Compensation Compensation { get; set; }

        [JsonPropertyName("OtherPaymentType")]
        public string OtherPaymentType { get; set; }

        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }
    }
}
