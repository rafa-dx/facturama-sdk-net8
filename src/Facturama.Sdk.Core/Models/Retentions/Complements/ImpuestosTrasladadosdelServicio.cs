using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed record ImpuestosTrasladadosdelServicio
    {
        /// <summary>
		/// Atributo requerido para señalar la base para el cálculo del
		/// impuesto, la determinación de la base se realiza de acuerdo
		/// con las disposiciones fiscales vigentes.No se permiten valores negativos.
		/// </summary>		
		public decimal Base { get; init; }

        /// <summary>
        /// Atributo requerido para señalar la clave del tipo de impuesto
        /// trasladado aplicable al servicio.	
        /// </summary>
        public string Impuesto { get; init; }

        ///// <summary>
        ///// Atributo requerido para señalar la clave del tipo de factor que
        ///// se aplica a la base del impuesto.
        ///// </summary>
        //[Required]
        //[RegularExpression("Tasa|Cuota")]
        //public string TipoFactor { get; init; }

        /// <summary>
        /// Atributo requerido para señalar el valor de la tasa o cuota del
        /// impuesto que se traslada para el presente servicio.
        /// </summary>
        public string TasaCuota { get; init; }

        /// <summary>
        /// Atributo requerido para señalar el importe del impuesto
        /// trasladado que aplica al servicio.No se permiten valores
        /// negativos.
        /// </summary>
        public decimal Importe { get; init; }
    }
}
