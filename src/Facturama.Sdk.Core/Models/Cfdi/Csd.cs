
namespace src.Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record Csd
    {
        public string Rfc { get; init; }
        public string Certificate { get; init; }
        public string PrivateKey { get; init; }
        public string PrivateKeyPassword { get; init; }

    }
}
