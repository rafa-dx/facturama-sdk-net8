using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Pedimentos
    {
        [JsonPropertyName("Pedimento")]
        public string Pedimento { get; init; }
    }
}
