using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Autotransporte
    {
        [JsonPropertyName("PermSCT")]
        public string PermSCT { get; init; }

        [JsonPropertyName("NumPermisoSCT")]
        public string NumPermisoSCT { get; init; }

        [JsonPropertyName("Seguros")]
        public Seguros Seguros { get; init; }

        [JsonPropertyName("IdentificacionVehicular")]
        public IdentificacionVehicular IdentificacionVehicular { get; init; }

        [JsonPropertyName("Remolques")]
        public Remolque[] Remolques { get; init; }
    }
}
