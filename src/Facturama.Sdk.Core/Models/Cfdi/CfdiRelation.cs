using System.Text.Json.Serialization;


namespace src.Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record CfdiRelation
    {
        [JsonPropertyName("Uuid")]
        public string Uuid { get; init; }
    }
}
