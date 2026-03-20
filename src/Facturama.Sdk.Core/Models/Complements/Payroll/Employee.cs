using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed class Employee
    {
        [JsonPropertyName("Outsourcing")]
        public Outsourcing[] Outsourcing { get; set; }

        [JsonPropertyName("Curp")]
        public string Curp { get; set; }

        [JsonPropertyName("SocialSecurityNumber")]
        public string SocialSecurityNumber { get; set; }

        [JsonPropertyName("StartDateLaborRelations")]
        public DateTime? StartDateLaborRelations { get; set; }

        [JsonPropertyName("ContractType")]
        public string ContractType { get; set; }

        [JsonPropertyName("Unionized")]
        public bool Unionized { get; set; }

        [JsonPropertyName("TypeOfJourney")]
        public string TypeOfJourney { get; set; }

        [JsonPropertyName("RegimeType")]
        public string RegimeType { get; set; }

        [JsonPropertyName("EmployeeNumber")]
        public string EmployeeNumber { get; set; }

        [JsonPropertyName("Department")]
        public string Department { get; set; }

        [JsonPropertyName("Position")]
        public string Position { get; set; }

        [JsonPropertyName("PositionRisk")]
        public string PositionRisk { get; set; }

        [JsonPropertyName("FrequencyPayment")]
        public string FrequencyPayment { get; set; }

        [JsonPropertyName("Bank")]
        public string Bank { get; set; }

        [JsonPropertyName("BankAccount")]
        public string BankAccount { get; set; }

        [JsonPropertyName("BaseSalary")]
        public decimal BaseSalary { get; set; }

        [JsonPropertyName("DailySalary")]
        public decimal? DailySalary { get; set; }

        [JsonPropertyName("FederalEntityKey")]
        public string FederalEntityKey { get; set; }
    }
}
