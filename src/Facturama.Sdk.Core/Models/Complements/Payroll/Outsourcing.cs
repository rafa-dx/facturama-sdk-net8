using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Outsourcing
    {

        [JsonPropertyName("RfcContractor")]
        public string RfcContractor { get; set; }

        [JsonPropertyName("PercentageTime")]
        public decimal PercentageTime { get; set; }
    }
}
