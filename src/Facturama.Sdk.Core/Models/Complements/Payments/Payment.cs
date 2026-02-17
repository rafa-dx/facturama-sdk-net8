using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Payments;

namespace src.Facturama.Sdk.Core.Models.Complements.Payments
{
    public sealed record Payment
    {
  
        public string Date { get; init; }
        public string PaymentForm { get; init; }
        public string Currency { get; init; }
        public decimal? ExchangeRate { get; init; }
        public decimal Amount { get; init; }
        public string OperationNumber { get; init; }
        public string RfcIssuerPayerAccount { get; init; }
        public string ForeignAccountNamePayer { get; init; }
        public string PayerAccount { get; init; }
        public string RfcReceiverBeneficiaryAccount { get; init; }
        public string BeneficiaryAccount { get; init; }
        public List<RelatedDocument> RelatedDocuments { get; init; }
        public List<Tax> Taxes { get; init; }
    }

      
    
}
