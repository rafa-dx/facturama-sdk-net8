using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Incapacity
    {

        [JsonPropertyName("Days")]
        public int Days { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("Amount")]
        public decimal Amount { get; set; }
    }
}
