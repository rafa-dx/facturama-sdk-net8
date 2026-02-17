using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record CfdiRelations
    {
        [JsonPropertyName("Type")]
        public string Type { get; init; }

        [JsonPropertyName("Cfdis")]
        public List<CfdiRelation> Cfdis { get; init; }
    }
}
