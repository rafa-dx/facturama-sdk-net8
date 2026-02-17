using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record TransporteMaritimo
    {
        public string PermSCT { get; init; }
        public string NumPermisoSCT { get; init; }
        public string NombreAseg { get; init; }
        public string NumPolizaSeguro { get; init; }
        public string TipoEmbarcacion { get; init; }

        public string Matricula { get; init; }

        public string NumeroOMI { get; init; }
        public int AnioEmbarcacion { get; init; }
        public string NombreEmbarc { get; init; }

        public string NacionalidadEmbarc { get; init; }

        public decimal UnidadesDeArqBruto { get; init; }

        public string TipoCarga { get; init; }

        public string NumCertITC { get; init; }
        public decimal Eslora { get; init; }
        public decimal Manga { get; init; }
        public decimal Calado { get; init; }

        public decimal Puntal { get; init; }
        public string LineaNaviera { get; init; }

        public string NombreAgenteNaviero { get; init; }

        public string NumAutorizacionNaviero { get; init; }
        public string NumViaje { get; init; }
        public string NumConocEmbarc { get; init; }

        public string PermisoTempNavegacion { get; init; }

        public Contenedor[] Contenedor { get; init; }
    }
}
