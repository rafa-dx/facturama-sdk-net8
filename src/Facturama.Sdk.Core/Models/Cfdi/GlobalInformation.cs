
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed class  GlobalInformation
    {
        [JsonPropertyName("Periodicity")]
        public string Periodicity { get; set; }

        [JsonPropertyName("Months")]
        public string Months { get; set; }

        [JsonPropertyName("Year")]
        public short Year { get; set; }
    }
}
