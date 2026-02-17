using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record ExtraHour
    {
        [JsonPropertyName("Days")]
        public int Days { get; init; }

        [JsonPropertyName("HoursType")]
        public string HoursType { get; init; }

        [JsonPropertyName("ExtraHours")]
        public int ExtraHours { get; init; }

        [JsonPropertyName("PaidAmount")]
        public decimal PaidAmount { get; init; }

    }
}
