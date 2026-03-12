using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record Item
    {
        [JsonPropertyName("IdProduct")]
        public  string? ProductId { get; init; }

        [JsonPropertyName("ProductCode")]
        public required string ProductCode { get; init; }

        [JsonPropertyName("SKU")]
        public string? SKU { get; init; }

        [JsonPropertyName("IdentificationNumber")]
        public string? IdentificationNumber { get; init; }

        [JsonPropertyName("Description")]
        public string Description { get; init; }

        [JsonPropertyName("Unit")]
        public string? Unit { get; init; }

        [JsonPropertyName("UnitCode")]
        public string? UnitCode { get; init; }

        [JsonPropertyName("UnitPrice")]
        public decimal UnitPrice { get; init; }

        [JsonPropertyName("Quantity")]
        public decimal Quantity { get; init; }

        [JsonPropertyName("Subtotal")]
        public decimal Subtotal { get; init; }

        [JsonPropertyName("TaxObject")]
        public string TaxObject { get; init; }

        [JsonPropertyName("ThirdPartyAccount")]
        public ThirdPartyAccountComplement ThirdPartyAccount { get; init; }

        [JsonPropertyName("Discount")]
        public decimal? Discount { get; init; }

        [JsonPropertyName("Taxes")]
        public List<Tax> Taxes { get; init; }

        [JsonPropertyName("PropertyTaxIDNumber")]
        public List<string> PropertyTaxIDNumber { get; init; }

        [JsonPropertyName("NumerosPedimento")]
        public List<string> NumerosPedimento { get; init; }

        [JsonPropertyName("Total")]
        public decimal Total { get; init; }

        public ItemComplement? Complement { get; init; }
    }
}
