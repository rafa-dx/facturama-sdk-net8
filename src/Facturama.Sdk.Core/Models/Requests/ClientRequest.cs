using Facturama.Sdk.Core.Models.Common;

using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record ClientRequest
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("EmailOp1")]
        public string? EmailOp1 { get; set; }

        [JsonPropertyName("Address")]
        public Address Address { get; set; }

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
        public string? TaxResidence { get; set; }

        [JsonPropertyName("NumRegIdTrib")]
        public string? NumRegIdTrib { get; set; }
    }
}
