using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed record ComisionDelServicio
    {
        /// <summary>
		/// Atributo opcional para registrar la base de la comisión del
		/// servicio de la plataforma, pagadas por personas físicas
		///	utilizando plataformas tecnológicas.
		/// </summary>
		public decimal? Base { get; init; }

        /// <summary>
        /// Atributo opcional para detallar el valor del porcentaje cobrado
        /// por la comisión del uso del servicio de las plataformas tecnológicas.
        /// </summary>
        public decimal? Porcentaje { get; init; }

        /// <summary>
        /// Atributo requerido para detallar el valor importe cobrado por
        /// la comisión del uso del servicio de las plataformas tecnológicas.
        /// </summary>
        public decimal Importe { get; init; }
    }
}
