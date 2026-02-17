using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
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
