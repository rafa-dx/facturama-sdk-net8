using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Retirement
    {
        [JsonPropertyName("TotalASinglePayment")]
        public decimal? TotalASinglePayment { get; init; }

        [JsonPropertyName("TotalParciality")]
        public decimal? TotalParciality { get; init; }

        [JsonPropertyName("DailyAmount")]
        public decimal? DailyAmount { get; init; }

        [JsonPropertyName("AccumulatedIncome")]
        public decimal AccumulatedIncome { get; init; }

        [JsonPropertyName("NonAccumulatedIncome")]
        public decimal NonAccumulatedIncome { get; init; }
    }
}
