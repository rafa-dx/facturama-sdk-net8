using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed class Item
    {
        [JsonPropertyName("IdProduct")]
        public  string? ProductId { get; set; }

        [JsonPropertyName("ProductCode")]
        public required string ProductCode { get; set; }

        [JsonPropertyName("SKU")]
        public string? SKU { get; set; }

        [JsonPropertyName("IdentificationNumber")]
        public string? IdentificationNumber { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("Unit")]
        public string? Unit { get; set; }

        [JsonPropertyName("UnitCode")]
        public string? UnitCode { get; set; }

        [JsonPropertyName("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("Quantity")]
        public decimal Quantity { get; set; }

        [JsonPropertyName("Subtotal")]
        public decimal Subtotal { get; set; }

        [JsonPropertyName("TaxObject")]
        public string TaxObject { get; set; }

        [JsonPropertyName("ThirdPartyAccount")]
        public ThirdPartyAccountComplement ThirdPartyAccount { get; set; }

        [JsonPropertyName("Discount")]
        public decimal? Discount { get; set; }

        [JsonPropertyName("Taxes")]
        public List<Tax> Taxes { get; set; }

        [JsonPropertyName("PropertyTaxIDNumber")]
        public List<string> PropertyTaxIDNumber { get; set; }

        [JsonPropertyName("NumerosPedimento")]
        public List<string> NumerosPedimento { get; set; }

        [JsonPropertyName("Total")]
        public decimal Total { get; set; }

        public ItemComplement? Complement { get; set; }
    }
}
