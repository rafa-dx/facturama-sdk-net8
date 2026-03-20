using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Indemnification
    {
        [JsonPropertyName("TotalPaid")]
        public decimal TotalPaid { get; set; }

        [JsonPropertyName("YearsOfService")]
        public int YearsOfService { get; set; }

        [JsonPropertyName("LastMonthlySalaryOrd")]
        public decimal LastMonthlySalaryOrd { get; set; }

        [JsonPropertyName("AccumulatedIncome")]
        public decimal AccumulatedIncome { get; set; }

        [JsonPropertyName("NonAccumulatedIncome")]
        public decimal NonAccumulatedIncome { get; set; }
    }
}
