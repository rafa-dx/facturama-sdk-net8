using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Donation;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.ForeignTrade;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Payments;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Payroll;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.TaxLegends;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Responses;
using System.Text.Json.Serialization;


namespace src.Facturama.Sdk.Core.Models.Complements
{
    public sealed record CfdiComplement
    {
        [JsonPropertyName("Donation")]
        public DonationComplement? Donation { get; init; }

        [JsonPropertyName("Payments")]
        public PaymentComplement? Payments { get; init; }

        [JsonPropertyName("TaxStamp")]
        public TaxStamp TaxStamp { get; set; }

        [JsonPropertyName("Payroll")]
        public PayrollComplement Payroll { get; set; }
        public ComplementoCartaPorte31 CartaPorte31 { get; set; }

        public TaxLegendsComplement TaxLegends { get; set; }


        public ForeignTradeComplement ForeignTrade { get; set; }





    }
}
