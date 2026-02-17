using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record CarroContenedor
    {
        public string TipoContenedor { get; init; }

        public decimal PesoContenedorVacio { get; init; }

        public decimal PesoNetoMercancia { get; init; }
    }
}
