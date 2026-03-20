using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Common
{
    public sealed class Tax
    {
        [JsonPropertyName("Total")]
        public decimal Total { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Base")]
        public decimal Base { get; set; }

        [JsonPropertyName("Rate")]
        public decimal Rate { get; set; }

        [JsonPropertyName("IsRetention")]
        public bool IsRetention { get; set; }

        [JsonPropertyName("IsQuota")]
        public bool IsQuota { get; set; }

        [JsonPropertyName("IsFederalTax")]
        public bool IsFederalTax { get; set; }
    }
}
