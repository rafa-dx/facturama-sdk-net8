using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.ForeignTrade
{
    public sealed record Receiver
    {
        /// <summary>
        ///     
        /// </summary>
        [JsonPropertyName("Address")]
        public Address Address { get; init; }

        /// <summary>
        ///  Número de identificación o registro fiscal del país de residencia para efectos fiscales del receptor del CFDI.
        /// </summary>
        [JsonPropertyName("NumRegIdTrib")]
        public string NumRegIdTrib { get; init; }
    }
}
