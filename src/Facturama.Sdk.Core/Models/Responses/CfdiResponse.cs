
using Facturama.Sdk.Core.Models.Cfdi;


namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record CfdiResponse 
    {
        public string Id { get; init; }
        public string CfdiType { get; init; }
        public string Type { get; init; }
        public string Serie { get; init; }
        public string Folio { get; init; }
        public string Date { get; init; }
        public string CertNumber { get; init; }
        public string PaymentTerms { get; init; }
        public string PaymentConditions { get; init; }
        public string PaymentMethod { get; init; }
        public string PaymentAccountNumber { get; init; }
        public string PaymentBankName { get; init; }
        public string ExpeditionPlace { get; init; }
        public decimal? ExchangeRate { get; init; }
        public string Currency { get; init; }
        public decimal Subtotal { get; init; }
        public decimal? Discount { get; init; }
        public decimal Total { get; init; }
        public string Observations { get; init; }
        public string OrdderNumber { get; init; }
        public Issuer Issuer { get; init; }
        public Receiver Receiver { get; init; }

        public List<Item> Items { get; init; }
        public List<Tax> Taxes { get; init; }   
        public Complement Complement { get; init; }
        public string Status { get; init; }
        public string OriginalString { get; init; }



    }

    public record Issuer
    {
        public string FiscalRegime { get; init; }
        public string Rfc { get; init; }
        public string TaxName { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
        public TaxAddress TaxAddress { get; init; }
        public IssuedIn IssuedIn { get; init; }
    }
    public record TaxAddress
    {
        public string Street { get; init; }
        public string ExteriorNumber { get; init; }
        public string InteriorNumber { get; init; }
        public string Neighborhood { get; init; }
        public string Municipality { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
    }

    public record IssuedIn
    {
        public string Id { get; init; }
        public string Street { get; init; }
        public string ExteriorNumber { get; init; }
        public string InteriorNumber { get; init; }
        public string Neighborhood { get; init; }
        public string Municipality { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }
    }

    public record Tax
    {
        public decimal Total { get; init; }
        public string Name { get; init; }
        public decimal Rate { get; init; }
        public string Type { get; init; }
    }

    public record Complement
    {
        public TaxStamp TaxStamp { get; init; }

    }

    public record TaxStamp
    {
        public string Uuid { get; init; }
        public string Date { get; init; }
        public string CfdiSign { get; init; }
        public string SatCertNumber { get; init; }
        public string SatSign { get; init; }
        public string RfcProvCertif { get; init; }
    }



}
