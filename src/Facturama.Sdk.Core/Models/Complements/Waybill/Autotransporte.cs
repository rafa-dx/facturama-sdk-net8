using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed class Autotransporte
    {
        [JsonPropertyName("PermSCT")]
        public string PermSCT { get; set; }

        [JsonPropertyName("NumPermisoSCT")]
        public string NumPermisoSCT { get; set; }

        [JsonPropertyName("Seguros")]
        public Seguros Seguros { get; set; }

        [JsonPropertyName("IdentificacionVehicular")]
        public IdentificacionVehicular IdentificacionVehicular { get; set; }

        [JsonPropertyName("Remolques")]
        public Remolque[] Remolques { get; set; }
    }
}
