using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed class Remolque
    {
        [JsonPropertyName("SubTipoRem")]
        public string SubTipoRem { get; set; }


        [JsonPropertyName("Placa")]
        public string Placa { get; set; }
    }
}
