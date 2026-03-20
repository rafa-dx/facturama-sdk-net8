using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class ExtraHour
    {
        [JsonPropertyName("Days")]
        public int Days { get; set; }

        [JsonPropertyName("HoursType")]
        public string HoursType { get; set; }

        [JsonPropertyName("ExtraHours")]
        public int ExtraHours { get; set; }

        [JsonPropertyName("PaidAmount")]
        public decimal PaidAmount { get; set; }

    }
}
