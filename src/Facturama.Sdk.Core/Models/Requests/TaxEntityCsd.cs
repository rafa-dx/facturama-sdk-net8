namespace Facturama.Sdk.Core.Models.Requests
{
    public sealed record TaxEntityCsd
    {
        public string Rfc { get; init; }    
        public string Certificate {  get; init; }
        public string PrivateKey { get; init; }
        public string PrivateKeyPassword { get; init; }

    }
}
