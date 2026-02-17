using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record ActionsOrTitles
    {

        [JsonPropertyName("MarketValue")]
        public decimal MarketValue { get; init; }

        [JsonPropertyName("PriceWhenGranting")]
        public decimal PriceWhenGranting { get; init; }
    }
}
