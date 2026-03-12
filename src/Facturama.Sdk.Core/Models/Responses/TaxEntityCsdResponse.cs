namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record TaxEntityCsdResponse
    {
        public string SerialNumber { get; init; }
        public string ExpirationDate { get; init; }
        public string Certificate { get; init; }
    }
}
