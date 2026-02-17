using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions
{
    public sealed record Extranjero
    {
        /// <summary>
        /// Atributo opcional para expresar el número de registro de identificación fiscal del receptor del documento cuando
        ///	sea residente en el extranjero.
        /// </summary>		
        public string NumRegIdTrib { get; init; }

        /// <summary>
        /// Atributo requerido para expresar el nombre, denominación o razón social del receptor del documento cuando sea
        /// residente en el extranjero.
        /// </summary>		
        public string NomDenRazSocR { get; init; }
    }
}
