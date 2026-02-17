using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record EmploymentSubsidy
    {
        [JsonPropertyName("Amount")]
        public decimal Amount { get; init; }
    }
}
