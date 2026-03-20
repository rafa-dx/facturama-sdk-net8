using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class EmploymentSubsidy
    {
        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }
    }
}
