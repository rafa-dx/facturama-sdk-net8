using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions
{
    public sealed record Retenciones
    {

        public string FolioInt { get; init; }

        /// <summary>
        /// Atributo requerido para la expresión de la fecha y hora de
        /// expedición del documento de retención e información de
        /// pagos. Se expresa en la forma yyyy-mmddThh:mm:ssTZD-6, de acuerdo con la especificación ISO 8601.
        /// </summary>		
        public string FechaExp { get; init; }

        /// <summary>
        /// Atributo requerido para expresar la clave de la retención e
        /// información de pagos de acuerdo al catálogo publicado en internet por el SAT.
        /// </summary>		
        public string CveRetenc { get; init; }

        /// <summary>
        /// Atributo opcional que expresa la descripción de la
        /// retención e información de pagos en caso de que en el
        ///	atributo CveRetenc se haya elegido el valor para 'otro tipo de retenciones'.
        /// </summary>	
        public string DescRetenc { get; init; }

        /// <summary>
        /// Nodo requerido para expresar la información del contribuyente emisor del documento
        /// electrónico de retenciones e información de pagos.
        /// </summary>		
        public Emisor Emisor { get; init; }

        /// <summary>
        /// Nodo requerido para expresar la información del contribuyente receptor.
        /// </summary>

        public Receptor Receptor { get; init; }

        /// <summary>
        /// Nodo requerido para expresar el periodo que ampara el documento de retenciones e información de pagos.
        /// </summary>
        public Periodo Periodo { get; init; }

        /// <summary>
        /// Nodo requerido para expresar el total de las retenciones e información de pagos efectuados en el período que ampara el documento.
        /// </summary>	
        public Totales Totales { get; init; }

        /// <summary>
        /// Nodo opcional donde se incluirá el complemento Timbre Fiscal Digital de manera
        /// obligatoria y los nodos complementarios determinados por el SAT, de acuerdo a las
        /// disposiciones particulares a un sector o actividad específica.
        /// </summary>
        public Complemento Complemento { get; init; }

        /// <summary>
        /// Identificador unico de Facturama
        /// </summary>
        public string Id { get; init; }

        /// <summary>
        /// Cadena original de la retencion
        /// </summary>
        public string CadenaOriginal { get; init; }

        /// <summary>
        /// Indica si la retencion esta cancelada
        /// </summary>
        public bool IsCanceled { get; init; }

        /// <summary>
        /// Sello Digital del CFDI (solo lectura)
        /// </summary>
        public string Sello { get; init; }
        /// </summary>
        public string LugarExpRetenc { get; init; }
    }
}
