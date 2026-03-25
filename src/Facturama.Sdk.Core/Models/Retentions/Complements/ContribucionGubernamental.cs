using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed class ContribucionGubernamental
    {

        /// <summary>
        /// Atributo requerido para registrar el importe de la contribución
        /// gubernamental pagada por los servicios realizados por
        ///	personas físicas utilizando plataformas tecnológicas.
        /// </summary>
        public decimal ImpContrib { get; set; }

        /// <summary>
        /// Atributo requerido para registrar la clave de la entidad
        /// federativa donde se efectúa el pago de la contribución
        ///	gubernamental.
        /// </summary>
        public string EntidadDondePagaLaContribucion { get; set; }
    }
}
