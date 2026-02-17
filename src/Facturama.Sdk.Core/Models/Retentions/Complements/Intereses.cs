using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed record Intereses
    {
        public string Version { get; init; }
        public InteresesSistFinanciero SistFinanciero { get; init; }
        public InteresesRetiroAORESRetInt RetiroAORESRetInt { get; init; }
        public InteresesOperFinancDerivad OperFinancDerivad { get; init; }
        public decimal MontIntNominal { get; init; }
        public decimal MontIntReal { get; init; }
        public decimal Perdida { get; init; }
    }
    public enum InteresesSistFinanciero
    {

        /// <remarks/>
        SI,

        /// <remarks/>
        NO,
    }
    public enum InteresesRetiroAORESRetInt
    {

        /// <remarks/>
        SI,

        /// <remarks/>
        NO,
    }
    public enum InteresesOperFinancDerivad
    {

        /// <remarks/>
        SI,

        /// <remarks/>
        NO,
    }
}
