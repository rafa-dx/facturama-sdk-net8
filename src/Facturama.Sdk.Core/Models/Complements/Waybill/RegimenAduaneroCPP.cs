using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed class RegimenAduaneroCPP
    {
        [JsonPropertyName("RegimenAduanero")]
        public string RegimenAduanero { get; set; }
    }
}
