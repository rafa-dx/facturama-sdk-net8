using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Perceptions
    {

        [JsonPropertyName("Details")]
        public PerceptionsDetail[] Details { get; init; }

        [JsonPropertyName("Retirement")]
        public Retirement Retirement { get; init; }

        [JsonPropertyName("Indemnification")]
        public Indemnification Indemnification { get; init; }
    }
}
