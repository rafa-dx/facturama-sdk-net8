using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.ForeignTrade
{
    public sealed record Issuer
    {
        /// <summary>
        /// Direccion del emisor del complemento de comercio exterior.
        /// </summary>
        [JsonPropertyName("Address")]
        public Address Address { get; init; }

        /// <summary>
        /// Atributo condicional para expresar la CURPS del emisor del CFDI cuando es persona física.
        /// </summary>
        [JsonPropertyName("Curp")]
        public string Curp { get; init; }
    }
}
