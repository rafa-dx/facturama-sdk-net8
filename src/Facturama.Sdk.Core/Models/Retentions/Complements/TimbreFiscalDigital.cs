using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed record TimbreFiscalDigital
    {
        public string Version { get; init; }
        public string Uuid { get; init; }
        public DateTime FechaTimbrado { get; init; }
        public string SelloCFD { get; init; }
        public string NoCertificadoSAT { get; init; }
        public string SelloSAT { get; init; }
    }
}
