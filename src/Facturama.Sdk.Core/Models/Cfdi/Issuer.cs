using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record Issuer
    {
        public string FiscalRegime { get; set; }
        public string Rfc { get; set; }
        public string Name { get; set; }
    }
}
