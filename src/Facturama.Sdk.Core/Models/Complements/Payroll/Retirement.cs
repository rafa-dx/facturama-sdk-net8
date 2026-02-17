using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
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
