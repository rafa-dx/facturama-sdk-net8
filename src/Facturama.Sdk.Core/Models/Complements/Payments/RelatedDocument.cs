using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;

namespace src.Facturama.Sdk.Core.Models.Complements.Payments
{
    public sealed record RelatedDocument
    {
        public string Uuid { get; init; }
        public string Serie { get; init; }
        public string Folio { get; init; }
        public string Currency { get; init; }
        public string EquivalenceDocRel { get; init; }
        public decimal? ExchangeRate { get; init; }
        public string PaymentMethod { get; init; }
        public int PartialityNumber { get; init; }
        public decimal PreviousBalanceAmount { get; init; }
        public decimal AmountPaid { get; init; }
        public string TaxObject { get; init; }

        public string ImpSaldoInsoluto { get; init; }

        public List<Tax> Taxes { get; init; }
    }
}
