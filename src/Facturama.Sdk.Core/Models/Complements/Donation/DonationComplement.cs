using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Donation
{
    public sealed record DonationComplement
    {
        /// <summary>
        /// Fecha del oficio en que se informó la autorización
        /// para recibir donativos deducibles.
        /// </summary>
        [JsonPropertyName("AuthorizationDate")]
        public DateTime AuthorizationDate { get; init; }

        /// <summary>
        /// Número del oficio de autorización o renovación.
        /// </summary>
        [JsonPropertyName("AuthorizationNumber")]
        public string AuthorizationNumber { get; init; } = default!;

        /// <summary>
        /// Leyenda que indica que el comprobante deriva de un donativo.
        /// </summary>
        [JsonPropertyName("Legend")]
        public string Legend { get; init; } = default!;
    }
}
