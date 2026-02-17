using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Incapacity
    {

        [JsonPropertyName("Days")]
        public int Days { get; init; }

        [JsonPropertyName("Type")]
        public string Type { get; init; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; init; }
    }
}
