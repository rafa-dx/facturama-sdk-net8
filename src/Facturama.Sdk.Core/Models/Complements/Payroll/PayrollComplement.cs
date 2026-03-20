using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class PayrollComplement
    {
        [JsonPropertyName("Issuer")]
        public Issuer Issuer { get; set; }

        [JsonPropertyName("Employee")]
        public Employee Employee { get; set; }

        [JsonPropertyName("Perceptions")]
        public Perceptions Perceptions { get; set; }

        [JsonPropertyName("Deductions")]
        public Deductions Deductions { get; set; }

        [JsonPropertyName("OtherPayments")]
        public OtherPayment[] OtherPayments { get; set; }

        [JsonPropertyName("Incapacities")]
        public Incapacity[] Incapacities { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [JsonPropertyName("setialPaymentDate")]
        public DateTime setialPaymentDate { get; set; }

        [JsonPropertyName("FinalPaymentDate")]
        public DateTime FinalPaymentDate { get; set; }

        [JsonPropertyName("DaysPaid")]
        public decimal DaysPaid { get; set; }

        [JsonPropertyName("DailySalary")]
        public decimal DailySalary { get; set; }

        [JsonPropertyName("BaseSalary")]
        public decimal BaseSalary { get; set; }
    }
}
