using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.ForeignTrade
{
    public sealed record Owner
    {
        /// <summary>
        /// Número de registro de identificación tributaria del propietario.
        /// </summary>
        [JsonPropertyName("NumRegIdTrib")]
        public string NumRegIdTrib { get; init; }

        /// <summary>
        /// Clave del país de residencia fiscal del propietario.
        /// </summary>
        [JsonPropertyName("TaxResidence")]
        public string TaxResidence { get; init; }
    }
}
