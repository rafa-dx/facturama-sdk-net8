using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Domicilio
    {
        [JsonPropertyName("Calle")]
        public string Calle { get; init; }

        [JsonPropertyName("NumeroExterior")]
        public string NumeroExterior { get; init; }

        [JsonPropertyName("NumeroInterior")]
        public string NumeroInterior { get; init; }

        [JsonPropertyName("Colonia")]
        public string Colonia { get; init; }

        [JsonPropertyName("Localidad")]
        public string Localidad { get; init; }

        [JsonPropertyName("Referencia")]
        public string Referencia { get; init; }

        [JsonPropertyName("Municipio")]
        public string Municipio { get; init; }

        [JsonPropertyName("Estado")]
        public string Estado { get; init; }

        [JsonPropertyName("Pais")]
        public string Pais { get; init; }

        [JsonPropertyName("CodigoPostal")]
        public string CodigoPostal { get; init; }
    }
}
