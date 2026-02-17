using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions
{
    public sealed record Receptor
    {
        /// <summary>
		/// Atributo requerido para expresar la nacionalidad del receptor del documento.
		/// </summary>		
		public string Nacionalidad { get; init; }

        /// <summary>
        /// Nodo requerido para expresar la información del contribuyente receptor en caso de que sea de nacionalidad mexicana.
        /// </summary>		
        public Nacional Nacional { get; init; }

        /// <summary>
        /// Nodo requerido para expresar la información del contribuyente receptor del documento cuando sea residente en el extranjero.
        /// </summary>		
        public Extranjero Extranjero { get; init; }
    }
}
