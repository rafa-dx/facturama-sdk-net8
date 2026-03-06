using Facturama.Sdk.Core.Models.Common;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record ClientResponse
    {
        [JsonPropertyName("Id")]
        public string Id { get; init; }

        [JsonPropertyName("Email")]
        public string Email { get; init; }

        [JsonPropertyName("EmailOp1")]
        public string EmailOp1 { get; init; }

        [JsonPropertyName("EmailOp2")]
        public string EmailOp2 { get; init; }

        [JsonPropertyName("Address")]
        public Address Address { get; init; }

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

        [JsonPropertyName("NumRegIdTrib")]
        public string NumRegIdTrib { get; init; }
    }
}
