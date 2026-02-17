using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public enum RegistroISTMO
    {
        [EnumMember(Value = "Sí")]
        Sí
    }
    public enum TranspInternac
    {
        [EnumMember(Value = "Si")]
        Si,

        [EnumMember(Value = "No")]
        No,
    }
    public enum TipoUbicacion
    {
        [EnumMember(Value = "Origen")]
        Origen,

        [EnumMember(Value = "Destino")]
        Destino,
    }
    public sealed record ComplementoCartaPorte31
    {
        [JsonPropertyName("IdCCP")]
        public string IdCCP { get; init; }

        [JsonPropertyName("TranspInternac")]
        public TranspInternac TranspInternac { get; init; }

        [JsonPropertyName("RegimensAduaneros")]
        public RegimenAduaneroCPP[] RegimenesAduaneros { get; init; }

        [JsonPropertyName("EntradaSalidaMerc")]
        public string EntradaSalidaMerc { get; init; }

        [JsonPropertyName("PaisOrigenDestino")]
        public string PaisOrigenDestino { get; init; }

        [JsonPropertyName("ViaEntradaSalida")]
        public string ViaEntradaSalida { get; init; }

        [JsonPropertyName("TotalDistRec")]
        public decimal? TotalDistRec { get; init; }

        [JsonPropertyName("RegistroISTMO")]
        public RegistroISTMO? RegistroISTMO { get; init; }

        [JsonPropertyName("UbicacionPoloOrigen")]
        public string UbicacionPoloOrigen { get; init; }

        [JsonPropertyName("UbicacionPoloDestino")]
        public string UbicacionPoloDestino { get; init; }

        [JsonPropertyName("Ubicaciones")]
        public Ubicacion[] Ubicaciones { get; init; }

        [JsonPropertyName("Mercancias")]
        public Mercancias Mercancias { get; init; }

        [JsonPropertyName("FiguraTransporte")]
        public TiposFigura[] FiguraTransporte { get; init; }
    }
}
