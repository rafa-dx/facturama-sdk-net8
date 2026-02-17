using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record RemolquesCCP
    {
        public string SubTipoRemCCP { get; init; }
        public string PlacaCCP { get; init; }
    }
}
