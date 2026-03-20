using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class PerceptionsDetail
    {
        [JsonPropertyName("ActionsOrTitles")]
        public ActionsOrTitles ActionsOrTitles { get; set; }

        [JsonPropertyName("ExtraHours")]
        public ExtraHour[] ExtraHours { get; set; }

        [JsonPropertyName("PerceptionType")]
        public string PerceptionType { get; set; }

        [JsonPropertyName("Code")]
        public string Code { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("TaxedAmount")]
        public decimal TaxedAmount { get; set; }

        [JsonPropertyName("ExemptAmount")]
        public decimal ExemptAmount { get; set; }
    }
}
