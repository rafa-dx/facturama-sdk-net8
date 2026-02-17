namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record Issuer
    {
        public string FiscalRegime { get; set; }
        public string Rfc { get; set; }
        public string Name { get; set; }
    }
}
