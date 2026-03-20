using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Retirement
    {
        [JsonPropertyName("TotalASinglePayment")]
        public decimal? TotalASinglePayment { get; set; }

        [JsonPropertyName("TotalParciality")]
        public decimal? TotalParciality { get; set; }

        [JsonPropertyName("DailyAmount")]
        public decimal? DailyAmount { get; set; }

        [JsonPropertyName("AccumulatedIncome")]
        public decimal AccumulatedIncome { get; set; }

        [JsonPropertyName("NonAccumulatedIncome")]
        public decimal NonAccumulatedIncome { get; set; }
    }
}
