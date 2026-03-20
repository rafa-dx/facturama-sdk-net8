using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class ActionsOrTitles
    {

        [JsonPropertyName("MarketValue")]
        public decimal MarketValue { get; set; }

        [JsonPropertyName("PriceWhenGranting")]
        public decimal PriceWhenGranting { get; set; }
    }
}
