using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
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
