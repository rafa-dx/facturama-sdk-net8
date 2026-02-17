using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record DerechosDePaso
    {
        public string TipoDerechoDePaso { get; init; }

        public string KilometrajePagado { get; init; }
    }
}
