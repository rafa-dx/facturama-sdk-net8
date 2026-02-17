using FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions
{
    public sealed record Complemento
    {
        /// <summary>
		/// Complemento para expresar la información sobre los servicios prestados
		/// por personas físicas que utilicen plataformas tecnológicas.
		/// </summary>
		public ServiciosPlataformasTecnologicas ServiciosPlataformasTecnologicas { get; init; }

        /// <summary>
        /// Timbre Fiscal
        /// </summary>
        public TimbreFiscalDigital TimbreFiscalDigital { get; init; }

        /// <summary>
        /// Complemento para expresar los intereses obtenidos por rendimiento en inversiones
        /// </summary>
        public Intereses Intereses { get; init; }
    }
}
