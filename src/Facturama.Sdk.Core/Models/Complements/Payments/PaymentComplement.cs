using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payments
{
    public sealed record PaymentComplement
    {
        [JsonPropertyName("Payments")]
        public IReadOnlyList<Payment> Payments { get; init; } = [];
    }
}
