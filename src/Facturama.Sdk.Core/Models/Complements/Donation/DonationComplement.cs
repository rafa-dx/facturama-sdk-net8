using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Donation
{
    public sealed class DonationComplement
    {
        /// <summary>
        /// Fecha del oficio en que se informó la autorización
        /// para recibir donativos deducibles.
        /// </summary>
        [JsonPropertyName("AuthorizationDate")]
        public DateTime AuthorizationDate { get; set; }

        /// <summary>
        /// Número del oficio de autorización o renovación.
        /// </summary>
        [JsonPropertyName("AuthorizationNumber")]
        public string AuthorizationNumber { get; set; } = default!;

        /// <summary>
        /// Leyenda que indica que el comprobante deriva de un donativo.
        /// </summary>
        [JsonPropertyName("Legend")]
        public string Legend { get; set; } = default!;
    }
}
