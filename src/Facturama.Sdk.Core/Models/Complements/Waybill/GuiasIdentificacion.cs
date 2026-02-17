using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record GuiasIdentificacion
    {
        [JsonPropertyName("NumeroGuiaIdentificacion")]
        public string NumeroGuiaIdentificacion { get; set; }

        [JsonPropertyName("DescripGuiaIdentificacion")]
        public string DescripGuiaIdentificacion { get; set; }

        [JsonPropertyName("PesoGuiaIdentificacion")]
        public decimal PesoGuiaIdentificacion { get; set; }
    }
}
