using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions
{
    public sealed record Periodo
    {

        /// <summary>
        /// Atributo requerido para la expresión del mes inicial del periodo de la retención e información de pagos.
        /// </summary>		
        public int MesIni { get; init; }

        /// <summary>
        /// Atributo requerido para la expresión del mes final del periodo de la retención e información de pagos.
        /// </summary>		
        public int MesFin { get; init; }

        /// <summary>
        /// Atributo requerido para la expresión del ejercicio fiscal (año).
        /// </summary>
        public int Ejerc { get; init; }
    }
}
