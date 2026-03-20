using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed class CfdiRelations
    {
        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("Cfdis")]
        public List<CfdiRelation> Cfdis { get; set; }
    }
}
