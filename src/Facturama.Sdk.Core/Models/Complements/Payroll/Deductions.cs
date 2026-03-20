using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Deductions
    {
        [JsonPropertyName("Details")]
        public DeductionsDetail[] Details { get; set; }
    }
}
