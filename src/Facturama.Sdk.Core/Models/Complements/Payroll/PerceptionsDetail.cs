using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record PerceptionsDetail
    {
        [JsonPropertyName("ActionsOrTitles")]
        public ActionsOrTitles ActionsOrTitles { get; init; }

        [JsonPropertyName("ExtraHours")]
        public ExtraHour[] ExtraHours { get; init; }

        [JsonPropertyName("PerceptionType")]
        public string PerceptionType { get; init; }

        [JsonPropertyName("Code")]
        public string Code { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("TaxedAmount")]
        public decimal TaxedAmount { get; init; }

        [JsonPropertyName("ExemptAmount")]
        public decimal ExemptAmount { get; init; }
    }
}
