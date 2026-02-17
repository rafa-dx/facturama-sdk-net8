using Facturama.Sdk.Core.Enums;
using Facturama.Sdk.Core.Models.Complements;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public abstract record CfdiBase
    {
        [JsonPropertyName("NameId")]
        public string NameId { get; init; }

        [JsonPropertyName("Folio")]
        public string Folio { get; init; }

        [JsonPropertyName("Serie")]
        public string Serie { get; init; }

        [JsonPropertyName("CfdiType")]
        public CfdiType CfdiType { get; init; }

        [JsonPropertyName("PaymentForm")]
        public string PaymentForm { get; init; }

        [JsonPropertyName("PaymentMethod")]
        public string PaymentMethod { get; init; }

        [JsonPropertyName("OrderNumber")]
        public string OrderNumber { get; init; }

        [JsonPropertyName("ExpeditionPlace")]
        public string ExpeditionPlace { get; init; }

        [JsonPropertyName("Date")]
        public DateTime? Date { get; init; }

        [JsonPropertyName("PaymentConditions")]
        public string PaymentConditions { get; init; }

        [JsonPropertyName("Observations")]
        public string Observations { get; init; }

        [JsonPropertyName("Exportation")]
        public string Exportation { get; init; }

        [JsonPropertyName("Currency")]
        public string Currency { get; init; }

        [JsonPropertyName("CurrencyExchangeRate")]
        public decimal? CurrencyExchangeRate { get; init; }

        [JsonPropertyName("PaymentBankName")]
        public string PaymentBankName { get; init; }

        [JsonPropertyName("PaymentAccountNumber")]
        public string PaymentAccountNumber { get; init; }

        [JsonPropertyName("Relations")]
        public CfdiRelations? Relations { get; init; }

        [JsonPropertyName("GlobalInformation")]
        public GlobalInformation? GlobalInformation { get; init; }


        [JsonPropertyName("Receiver")]
        public required Receiver Receiver { get; init; }

        [JsonPropertyName("Items")]
        public List<Item> Items { get; init; }

        [JsonPropertyName("Complemento")]
        public CfdiComplement? Complement { get; init; }
    }
}
