using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Indemnification
    {
        [JsonPropertyName("TotalPaid")]
        public decimal TotalPaid { get; init; }

        [JsonPropertyName("YearsOfService")]
        public int YearsOfService { get; init; }

        [JsonPropertyName("LastMonthlySalaryOrd")]
        public decimal LastMonthlySalaryOrd { get; init; }

        [JsonPropertyName("AccumulatedIncome")]
        public decimal AccumulatedIncome { get; init; }

        [JsonPropertyName("NonAccumulatedIncome")]
        public decimal NonAccumulatedIncome { get; init; }
    }
}
