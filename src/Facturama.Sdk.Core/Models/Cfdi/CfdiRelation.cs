using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record CfdiRelation
    {
        [JsonPropertyName("Uuid")]
        public string Uuid { get; init; }
    }
}
