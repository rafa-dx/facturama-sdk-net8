using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Issuer
    {
        [JsonPropertyName("EntitySNCF")]
        public EntitySncf EntitySncf { get; set; }

        [JsonPropertyName("Curp")]
        public string Curp { get; set; }

        [JsonPropertyName("EmployerRegistration")]
        public string EmployerRegistration { get; set; }

        [JsonPropertyName("FromEmployerRfc")]
        public string FromEmployerRfc { get; set; }
    }
}
