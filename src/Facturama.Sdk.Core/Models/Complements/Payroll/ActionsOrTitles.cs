using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record ActionsOrTitles
    {

        [JsonPropertyName("MarketValue")]
        public decimal MarketValue { get; init; }

        [JsonPropertyName("PriceWhenGranting")]
        public decimal PriceWhenGranting { get; init; }
    }
}
