using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Issuer
    {
        [JsonPropertyName("EntitySNCF")]
        public EntitySncf EntitySncf { get; init; }

        [JsonPropertyName("Curp")]
        public string Curp { get; init; }

        [JsonPropertyName("EmployerRegistration")]
        public string EmployerRegistration { get; init; }

        [JsonPropertyName("FromEmployerRfc")]
        public string FromEmployerRfc { get; init; }
    }
}
