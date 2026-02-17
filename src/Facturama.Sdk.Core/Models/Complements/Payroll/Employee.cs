using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.Payroll
{
    public sealed record Employee
    {
        [JsonPropertyName("Outsourcing")]
        public Outsourcing[] Outsourcing { get; init; }

        [JsonPropertyName("Curp")]
        public string Curp { get; init; }

        [JsonPropertyName("SocialSecurityNumber")]
        public string SocialSecurityNumber { get; init; }

        [JsonPropertyName("StartDateLaborRelations")]
        public DateTime? StartDateLaborRelations { get; init; }

        [JsonPropertyName("ContractType")]
        public string ContractType { get; init; }

        [JsonPropertyName("Unionized")]
        public bool Unionized { get; init; }

        [JsonPropertyName("TypeOfJourney")]
        public string TypeOfJourney { get; init; }

        [JsonPropertyName("RegimeType")]
        public string RegimeType { get; init; }

        [JsonPropertyName("EmployeeNumber")]
        public string EmployeeNumber { get; init; }

        [JsonPropertyName("Department")]
        public string Department { get; init; }

        [JsonPropertyName("Position")]
        public string Position { get; init; }

        [JsonPropertyName("PositionRisk")]
        public string PositionRisk { get; init; }

        [JsonPropertyName("FrequencyPayment")]
        public string FrequencyPayment { get; init; }

        [JsonPropertyName("Bank")]
        public string Bank { get; init; }

        [JsonPropertyName("BankAccount")]
        public string BankAccount { get; init; }

        [JsonPropertyName("BaseSalary")]
        public decimal BaseSalary { get; init; }

        [JsonPropertyName("DailySalary")]
        public decimal? DailySalary { get; init; }

        [JsonPropertyName("FederalEntityKey")]
        public string FederalEntityKey { get; init; }
    }
}
