
using System.Text.Json.Serialization;


namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Request
{
    public sealed record CustumerValidateRequest
    {
        /// <summary>
        /// Rfc, consultado
        /// </summary>
        [JsonPropertyName("Rfc")]
        public string Rfc { get; init; }

        /// <summary>
        /// Name, Nombre Fiscal
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; init; }

        /// <summary>
        /// ZipCode, Codigo postal 
        /// </summary>
        [JsonPropertyName("ZipCode")]
        public string ZipCode { get; init; }

        /// <summary>
        /// FiscalRegime, Regimen Fiscal
        /// </summary>
        [JsonPropertyName("FiscalRegime")]
        public string FiscalRegime { get; init; }
    }
}
