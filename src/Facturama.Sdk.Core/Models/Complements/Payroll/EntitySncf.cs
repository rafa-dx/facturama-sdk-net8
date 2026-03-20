using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class EntitySncf
    {
        [JsonPropertyName("OriginSource")]
        public string OriginSource { get; set; }

        [JsonPropertyName("AmountOriginSource")]
        public decimal? AmountOriginSource { get; set; }
    }
}
