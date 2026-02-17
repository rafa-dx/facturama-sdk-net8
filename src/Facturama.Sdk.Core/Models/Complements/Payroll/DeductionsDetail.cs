using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
     public sealed record DeductionsDetail
    {
        [JsonPropertyName("DeduccionType")]
        public string DeduccionType { get; init; }

        [JsonPropertyName("Code")]
        public string Code { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; init; }
    }
}
