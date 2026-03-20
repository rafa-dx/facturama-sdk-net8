using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
     public sealed class DeductionsDetail
    {
        [JsonPropertyName("DeduccionType")]
        public string DeduccionType { get; set; }

        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }
    }
}
