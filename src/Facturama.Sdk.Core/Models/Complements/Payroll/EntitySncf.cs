using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record EntitySncf
    {
        [JsonPropertyName("OriginSource")]
        public string OriginSource { get; init; }

        [JsonPropertyName("AmountOriginSource")]
        public decimal? AmountOriginSource { get; init; }
    }
}
