using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.ForeignTrade
{
    public sealed record Recipient
    {
        /// <summary>
        ///  Número de identificación o registro fiscal del país de residencia para efectos fiscales del destinatario de la mercancía exportada.
        /// </summary>
        [JsonPropertyName("NumRegIdTrib")]
        public string NumRegIdTrib { get; init; }

        /// <summary>
        /// Nombre completo, denominación o razón social del destinatario de la mercancía exportada.
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; init; }

        [JsonPropertyName("Address")]
        public List<Address> Addresses { get; init; }
    }
}
