using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record TransporteAereo
    {
        public string PermSCT { get; init; }

        public string NumPermisoSCT { get; init; }


        public string MatriculaAeronave { get; init; }

        public string NombreAseg { get; init; }

        public string NumPolizaSeguro { get; init; }

        public string NumeroGuia { get; init; }
        public string LugarContrato { get; init; }

        public string CodigoTransportista { get; init; }
        public string NumRegIdTribTranspor { get; init; }
        public string ResidenciaFiscalTranspor { get; init; }
        public string NombreTransportista { get; init; }
        public string RFCEmbarcador { get; init; }
        public string NumRegIdTribEmbarc { get; init; }
        public string ResidenciaFiscalEmbarc { get; init; }
        public string NombreEmbarcador { get; init; }
    }
}
