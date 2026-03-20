using Facturama.Sdk.Core.Enums;
using Facturama.Sdk.Core.Models.Complements;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public abstract class CfdiBase
    {
        [JsonPropertyName("NameId")]
        public string NameId { get; set; }

        [JsonPropertyName("Folio")]
        public string Folio { get; set; }

        [JsonPropertyName("Serie")]
        public string Serie { get; set; }

        [JsonPropertyName("CfdiType")]
        public string CfdiType { get; set; }

        [JsonPropertyName("PaymentForm")]
        public string PaymentForm { get; set; }

        [JsonPropertyName("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("OrderNumber")]
        public string OrderNumber { get; set; }

        [JsonPropertyName("ExpeditionPlace")]
        public string ExpeditionPlace { get; set; }

        [JsonPropertyName("Date")]
        //public DateTime? Date { get; set; }
        public string Date { get; set; }

        [JsonPropertyName("PaymentConditions")]
        public string PaymentConditions { get; set; }

        [JsonPropertyName("Observations")]
        public string Observations { get; set; }

        [JsonPropertyName("Exportation")]
        public string Exportation { get; set; }

        [JsonPropertyName("Currency")]
        public string Currency { get; set; }

        [JsonPropertyName("CurrencyExchangeRate")]
        public decimal? CurrencyExchangeRate { get; set; }

        [JsonPropertyName("PaymentBankName")]
        public string PaymentBankName { get; set; }

        [JsonPropertyName("PaymentAccountNumber")]
        public string PaymentAccountNumber { get; set; }

        [JsonPropertyName("Relations")]
        public CfdiRelations? Relations { get; set; }

        [JsonPropertyName("GlobalInformation")]
        public GlobalInformation? GlobalInformation { get; set; }


        [JsonPropertyName("Receiver")]
        public required Receiver Receiver { get; set; }

        [JsonPropertyName("Items")]
        public List<Item> Items { get; set; }

        [JsonPropertyName("Complemento")]
        public CfdiComplement? Complement { get; set; }
    }
}
