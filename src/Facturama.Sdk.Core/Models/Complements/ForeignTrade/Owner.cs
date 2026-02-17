using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.ForeignTrade
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
