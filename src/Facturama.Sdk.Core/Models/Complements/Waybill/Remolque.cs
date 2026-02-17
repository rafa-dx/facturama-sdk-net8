using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Remolque
    {
        [JsonPropertyName("SubTipoRem")]
        public string SubTipoRem { get; init; }


        [JsonPropertyName("Placa")]
        public string Placa { get; init; }
    }
}
