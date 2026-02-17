using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record TiposFigura
    {
        public PartesTransporte[] PartesTransporte { get; init; }
        public string TipoFigura { get; init; }
        public string RFCFigura { get; init; }

        public string NumLicencia { get; init; }

        public string NombreFigura { get; init; }

        public string NumRegIdTribFigura { get; init; }
        public string ResidenciaFiscalFigura { get; init; }

        public Domicilio Domicilio { get; init; }
    }
}
