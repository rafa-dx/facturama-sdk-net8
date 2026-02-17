using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Perceptions
    {

        [JsonPropertyName("Details")]
        public PerceptionsDetail[] Details { get; init; }

        [JsonPropertyName("Retirement")]
        public Retirement Retirement { get; init; }

        [JsonPropertyName("Indemnification")]
        public Indemnification Indemnification { get; init; }
    }
}
