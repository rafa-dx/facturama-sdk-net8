using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Contenedor
    {
        public string MatriculaContenedor { get; set; }
        public string TipoContenedor { get; set; }
        public string NumPrecinto { get; set; }
        public string IdCCPRelacionado { get; set; }
        public string PlacaVMCCP { get; set; }
        public DateTime FechaCertificacionCCP { get; set; }

        public RemolquesCCP[] RemolquesCCP { get; set; }
    }
}
