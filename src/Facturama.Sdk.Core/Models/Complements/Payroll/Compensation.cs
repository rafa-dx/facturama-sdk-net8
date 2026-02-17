using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Compensation
    {
        [JsonPropertyName("PositiveBalance")]
        public decimal PositiveBalance { get; init; }

        [JsonPropertyName("Year")]
        public short Year { get; init; }

        [JsonPropertyName("RemainingPositiveBalance")]
        public decimal RemainingPositiveBalance { get; init; }
    }
}
