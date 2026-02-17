
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record  GlobalInformation
    {
        [JsonPropertyName("Periodicity")]
        public string Periodicity { get; init; }

        [JsonPropertyName("Months")]
        public string Months { get; init; }

        [JsonPropertyName("Year")]
        public short Year { get; init; }
    }
}
