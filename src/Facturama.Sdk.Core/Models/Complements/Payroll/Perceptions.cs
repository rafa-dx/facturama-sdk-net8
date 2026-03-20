using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Perceptions
    {

        [JsonPropertyName("Details")]
        public PerceptionsDetail[] Details { get; set; }

        [JsonPropertyName("Retirement")]
        public Retirement Retirement { get; set; }

        [JsonPropertyName("Indemnification")]
        public Indemnification Indemnification { get; set; }
    }
}
