using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record PayrollComplement
    {
        [JsonPropertyName("Issuer")]
        public Issuer Issuer { get; init; }

        [JsonPropertyName("Employee")]
        public Employee Employee { get; init; }

        [JsonPropertyName("Perceptions")]
        public Perceptions Perceptions { get; init; }

        [JsonPropertyName("Deductions")]
        public Deductions Deductions { get; init; }

        [JsonPropertyName("OtherPayments")]
        public OtherPayment[] OtherPayments { get; init; }

        [JsonPropertyName("Incapacities")]
        public Incapacity[] Incapacities { get; init; }

        [JsonPropertyName("Type")]
        public string Type { get; init; }

        [JsonPropertyName("PaymentDate")]
        public DateTime PaymentDate { get; init; }

        [JsonPropertyName("InitialPaymentDate")]
        public DateTime InitialPaymentDate { get; init; }

        [JsonPropertyName("FinalPaymentDate")]
        public DateTime FinalPaymentDate { get; init; }

        [JsonPropertyName("DaysPaid")]
        public decimal DaysPaid { get; init; }

        [JsonPropertyName("DailySalary")]
        public decimal DailySalary { get; init; }

        [JsonPropertyName("BaseSalary")]
        public decimal BaseSalary { get; init; }
    }
}
