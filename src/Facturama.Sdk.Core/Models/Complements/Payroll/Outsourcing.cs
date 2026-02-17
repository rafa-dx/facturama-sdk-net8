using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Outsourcing
    {

        [JsonPropertyName("RfcContractor")]
        public string RfcContractor { get; init; }

        [JsonPropertyName("PercentageTime")]
        public decimal PercentageTime { get; init; }
    }
}
