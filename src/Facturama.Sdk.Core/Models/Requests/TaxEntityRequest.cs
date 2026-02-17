using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Request
{
    public sealed record TaxEntityRequest
    {  
        public string FiscalRegime { get; set; }        
        public string ComercialName { get; set; }        
        public string Rfc { get; set; }       
        public string TaxName { get; set; }       
        public string Email { get; set; }       
        public string Phone { get; set; }      
        public Address TaxAddress { get; set; } 
        public string PasswordSat { get; set; }
    }
}
