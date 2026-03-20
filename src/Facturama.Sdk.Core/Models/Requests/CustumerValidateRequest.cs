
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record CustumerValidateRequest
    {
        /// <summary>
        /// Rfc, consultado
        /// </summary>
        [JsonPropertyName("Rfc")]
        public string Rfc { get; set; }

        /// <summary>
        /// Name, Nombre Fiscal
        /// </summary>
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// ZipCode, Codigo postal 
        /// </summary>
        [JsonPropertyName("ZipCode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// FiscalRegime, Regimen Fiscal
        /// </summary>
        [JsonPropertyName("FiscalRegime")]
        public string FiscalRegime { get; set; }
    }
}
