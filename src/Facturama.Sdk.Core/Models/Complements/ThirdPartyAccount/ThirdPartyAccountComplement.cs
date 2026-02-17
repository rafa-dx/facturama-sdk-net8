using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount
{
    public sealed record ThirdPartyAccountComplement
    {

        [JsonPropertyName("Rfc")]
        public string Rfc { get; init; }

        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("FiscalRegime")]
        public string FiscalRegime { get; init; }

        [JsonPropertyName("TaxZipCode")]
        public string TaxZipCode { get; init; }
    }
}
