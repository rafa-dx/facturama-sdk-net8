using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;
using System.Text.Json.Serialization;

namespace src.Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record Receiver
    {
        [JsonPropertyName("Id")]
        public string Id { get; init; }

        [JsonPropertyName("Rfc")]
        public string Rfc { get; init; }

        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("CfdiUse")]
        public string CfdiUse { get; init; }

        [JsonPropertyName("FiscalRegime")]
        public string FiscalRegime { get; init; }

        [JsonPropertyName("TaxZipCode")]
        public string TaxZipCode { get; init; }

        [JsonPropertyName("TaxResidence")]
        public string TaxResidence { get; init; }

        [JsonPropertyName("TaxRegistrationNumber")]
        public string TaxRegistrationNumber { get; init; }

        [JsonPropertyName("Address")]
        public Address Address { get; init; }
    }
}
