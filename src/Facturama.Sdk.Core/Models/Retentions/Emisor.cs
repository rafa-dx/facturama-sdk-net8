using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions
{
    public sealed record Emisor
    {
        /// <summary>
        /// Atributo requerido para incorporar la clave en el Registro
        /// Federal de Contribuyentes correspondiente al
        ///	contribuyente emisor del documento de retención e información de pagos, sin guiones o espacios.
        /// </summary>		
        public string RfcEmisor { get; init; }

        /// <summary>
        /// Atributo opcional para el nombre, denominación o razón
        /// social del contribuyente emisor del documento de retención e información de pagos
        /// </summary>		
        public string NomDenRazSocE { get; init; }

        /// <summary>
        /// Atributo opcional para la Clave Única del Registro
        /// Poblacional del contribuyente emisor del documento de
        ///	retención e información de pagos.
        /// </summary>		
        public string CurpE { get; init; }

        /// <summary>
        /// Atributo requerido para incorporar la clave del régimen del contribuyente
        /// emisor del comprobante que ampara retenciones e información de
        /// pagos.
        /// </summary>
        public string RegimenFiscalE { get; init; }
    }
}
