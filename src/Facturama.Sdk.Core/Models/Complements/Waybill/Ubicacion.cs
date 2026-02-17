using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Ubicacion
    {
        [JsonPropertyName("Domicilio")]
        public Domicilio Domicilio { get; init; }

        [JsonPropertyName("TipoUbicacion")]
        public TipoUbicacion TipoUbicacion { get; init; }

        [JsonPropertyName("IDUbicacion")]
        public string IDUbicacion { get; init; }

        [JsonPropertyName("RFCRemitenteDestinatario")]
        public string RFCRemitenteDestinatario { get; init; }

        [JsonPropertyName("NombreRemitenteDestinatario")]
        public string NombreRemitenteDestinatario { get; init; }

        [JsonPropertyName("NumRegIdTrib")]
        public string NumRegIdTrib { get; init; }

        [JsonPropertyName("ResidenciaFiscal")]
        public string ResidenciaFiscal { get; init; }

        [JsonPropertyName("NumEstacion")]
        public string NumEstacion { get; init; }

        [JsonPropertyName("NombreEstacion")]
        public string NombreEstacion { get; init; }

        [JsonPropertyName("NavegacionTrafico")]
        public string NavegacionTrafico { get; init; }

        [JsonPropertyName("FechaHoraSalidaLlegada")]
        public DateTime FechaHoraSalidaLlegada { get; init; }

        [JsonPropertyName("TipoEstacion")]
        public string TipoEstacion { get; init; }

        [JsonPropertyName("DistanciaRecorrida")]
        public decimal DistanciaRecorrida { get; init; }
    }
}
