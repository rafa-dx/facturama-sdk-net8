using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Retentions
{
    public sealed class Totales
    {
        /// <summary>
		/// Atributo requerido para expresar el total del monto de la operación que se relaciona en el comprobante.
		/// </summary>		
		public decimal montoTotOperacion { get; set; }

        /// <summary>
        /// Atributo requerido para expresar el total del monto gravado de la operación que se relaciona en el comprobante.
        /// </summary>
        public decimal montoTotGrav { get; set; }

        /// <summary>
        /// Atributo requerido para expresar el total del monto exento de la operación que se relaciona en el comprobante.
        /// </summary>
        public decimal montoTotExent { get; set; }

        /// <summary>
        /// Atributo requerido para expresar el monto total de las retenciones.Sumatoria de los montos de retención del nodo ImpRetenidos.
        /// </summary>
        public decimal montoTotRet { get; set; }

        /// <summary>
        /// Nodo opcional para expresar el total de los impuestos retenidos que se desprenden de
        /// los conceptos expresados en el documento de retenciones e información de pagos.
        /// </summary>
        public List<ImpRetenido> ImpRetenidos { get; set; }
    }
}
