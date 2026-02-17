using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Mercancias
    {

        [JsonPropertyName("PesoBrutoTotal")]
        public decimal PesoBrutoTotal { get; init; }

        [JsonPropertyName("UnidadPeso")]
        public string UnidadPeso { get; init; }


        [JsonPropertyName("PesoNetoTotal")]
        public decimal PesoNetoTotal { get; init; }

        [JsonPropertyName("NumTotalMercancias")]
        public int NumTotalMercancias { get; init; }

        [JsonPropertyName("CargoPorTasacion")]
        public decimal CargoPorTasacion { get; init; }

        [JsonPropertyName("LogisticaInversaRecoleccionDevolucion")]
        public string LogisticaInversaRecoleccionDevolucion { get; init; }


        [JsonPropertyName("Mercancia")]
        public Mercancia[] Mercancia { get; init; }

        [JsonPropertyName("Autotransporte")]
        public Autotransporte Autotransporte { get; init; }

        [JsonPropertyName("TransporteMaritimo")]
        public TransporteMaritimo TransporteMaritimo { get; init; }

        [JsonPropertyName("TransporteAereo")]
        public TransporteAereo TransporteAereo { get; init; }

        [JsonPropertyName("TransporteFerroviario")]
        public TransporteFerroviario TransporteFerroviario { get; init; }
    }
}
