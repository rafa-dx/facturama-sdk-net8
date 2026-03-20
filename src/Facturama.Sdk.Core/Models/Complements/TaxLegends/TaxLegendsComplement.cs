using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.TaxLegends
{
    public sealed class TaxLegendsComplement
    {
        [JsonPropertyName("Legends")]
        public Legend[] Legends { get; set; }

    }
    public class Legend
    {
        [JsonPropertyName("TaxProvision")]
        public string TaxProvision { get; set; }

        [JsonPropertyName("Norm")]
        public string Norm { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }
    }
}

