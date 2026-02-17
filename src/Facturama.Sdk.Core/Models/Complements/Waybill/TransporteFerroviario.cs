using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record TransporteFerroviario
    {
        public string TipoDeServicio { get; init; }
        public string TipoDeTrafico { get; init; }
        public string NombreAseg { get; init; }
        public string NumPolizaSeguro { get; init; }
        public string Concesionario { get; init; }
        public DerechosDePaso[] DerechosDePaso { get; init; }

        public Carro[] Carro { get; init; }
    }
}
