using Facturama.Sdk.Core.Models.Common;
using System.Text.Json.Serialization;

namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed class Receiver
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Rfc")]
        public string Rfc { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("CfdiUse")]
        public string CfdiUse { get; set; }

        [JsonPropertyName("FiscalRegime")]
        public string FiscalRegime { get; set; }

        [JsonPropertyName("TaxZipCode")]
        public string TaxZipCode { get; set; }

        [JsonPropertyName("TaxResidence")]
        public string TaxResidence { get; set; }

        [JsonPropertyName("TaxRegistrationNumber")]
        public string TaxRegistrationNumber { get; set; }

        [JsonPropertyName("Address")]
        public Address Address { get; set; }
    }
}
