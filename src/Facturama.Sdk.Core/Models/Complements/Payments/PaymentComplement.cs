using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payments
{
    public sealed class PaymentComplement
    {
        [JsonPropertyName("Payments")]
        public IReadOnlyList<Payment> Payments { get; set; } = [];
    }
}
