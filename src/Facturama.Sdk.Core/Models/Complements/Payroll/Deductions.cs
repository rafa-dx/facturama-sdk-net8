using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Deductions
    {
        [JsonPropertyName("Details")]
        public DeductionsDetail[] Details { get; set; }
    }
}
