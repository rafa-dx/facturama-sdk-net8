using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Compensation
    {
        [JsonPropertyName("PositiveBalance")]
        public decimal PositiveBalance { get; set; }

        [JsonPropertyName("Year")]
        public short Year { get; set; }

        [JsonPropertyName("RemainingPositiveBalance")]
        public decimal RemainingPositiveBalance { get; set; }
    }
}
