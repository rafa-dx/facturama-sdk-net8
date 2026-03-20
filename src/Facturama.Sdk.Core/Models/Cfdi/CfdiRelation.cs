using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed class CfdiRelation
    {
        [JsonPropertyName("Uuid")]
        public string Uuid { get; set; }
    }
}
