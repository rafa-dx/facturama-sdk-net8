using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Retentions
{
    public sealed class Periodo
    {

        /// <summary>
        /// Atributo requerido para la expresión del mes inicial del periodo de la retención e información de pagos.
        /// </summary>		
        public string MesIni { get; set; }

        /// <summary>
        /// Atributo requerido para la expresión del mes final del periodo de la retención e información de pagos.
        /// </summary>		
        public string MesFin { get; set; }

        /// <summary>
        /// Atributo requerido para la expresión del ejercicio fiscal (año).
        /// </summary>
        public string Ejerc { get; set; }
    }
}
