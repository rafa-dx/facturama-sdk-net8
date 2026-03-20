using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount
{
    public sealed class ThirdPartyAccountComplement
    {

        [JsonPropertyName("Rfc")]
        public string Rfc { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("FiscalRegime")]
        public string FiscalRegime { get; set; }

        [JsonPropertyName("TaxZipCode")]
        public string TaxZipCode { get; set; }
    }
}
