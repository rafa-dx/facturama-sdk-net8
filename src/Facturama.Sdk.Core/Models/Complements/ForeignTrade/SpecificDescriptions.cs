using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.ForeignTrade
{
    public sealed record SpecificDescriptions
    {
        /// <summary>
        /// Marca de la Mercancia
        /// </summary>
        [JsonPropertyName("Brand")]
        public string Brand { get; init; }

        /// <summary>
        /// Modelo de la mercancía
        /// </summary>
        [JsonPropertyName("Model")]
        public string Model { get; init; }

        /// <summary>
        /// Submodelo de la mercancía
        /// </summary>
        [JsonPropertyName("Submodel")]
        public string SubModel { get; init; }

        /// <summary>
        /// Número de serie de la mercancía
        /// </summary>  
        [JsonPropertyName("SerialNumber")]
        public string SerialNumber { get; init; }
    }
}
