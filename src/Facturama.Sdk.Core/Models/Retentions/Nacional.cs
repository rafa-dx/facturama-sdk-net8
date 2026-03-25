using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Retentions
{
    public sealed class Nacional
    {
        /// <summary>
        /// Atributo requerido para la clave del Registro Federal de
        /// Contribuyentes correspondiente al contribuyente receptor	del documento.
        /// </summary>		
        public string RFCRecep { get; set; }

        /// <summary>
        /// Atributo opcional para el nombre, denominación o razón social del contribuyente receptor del documento.
        /// </summary>

        public string NomDenRazSocR { get; set; }

        /// <summary>
        /// Atributo opcional para la Clave Única del Registro Poblacional del contribuyente receptor del documento.
        /// </summary>		
        public string CurpR { get; set; }

        /// <summary>
        /// Atributo requerido para registrar el código postal del domicilio fiscal del
        /// receptor del comprobante que ampara retenciones e información de
        /// pagos.
        /// </summary>
        public string DomicilioFiscalR { get; set; }
    }
}
