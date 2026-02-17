using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed record DetallesDelServicio
    {
        /// <summary>
        /// Nodo requerido para detallar la información de los Impuestos
        /// trasladados de los servicios realizados por personas físicas utilizando
        ///	plataformas tecnológicas.
        /// </summary>

        public ImpuestosTrasladadosdelServicio ImpuestosTrasladadosdelServicio { get; init; }

        /// <summary>
        /// Nodo opcional para detallar la información de las contribuciones
        /// gubernamentales pagadas por los servicios realizados por personas
        /// físicas utilizando plataformas tecnológicas.
        /// </summary>
        public ContribucionGubernamental ContribucionGubernamental { get; init; }

        /// <summary>
        /// Nodo requerido para detallar la información de la comisión pagada por el
        /// uso de plataformas tecnológicas por cada servicio relacionado.
        /// </summary>

        public ComisionDelServicio ComisionDelServicio { get; init; }

        /// <summary>
        /// Atributo requerido para expresar la clave de la forma de pago con la que se liquida el servicio.
        /// </summary>
        public string FormaPagoServ { get; init; }

        /// <summary>
        /// Atributo requerido para expresar la clave del tipo de servicio prestado.
        /// </summary>
        public string TipoDeServ { get; init; }

        /// <summary>
        /// Atributo condicional para identificar el subtipo del servicio prestado.
        /// </summary>
        public string SubTipServ { get; init; }

        /// <summary>
        /// Atributo opcional para registrar el RFC del tercero autorizado como personal de apoyo, por quien está registrado en la
        /// plataforma tecnológica para prestar servicios.	
        /// </summary>
        public string RfcTerceroAutorizado { get; init; }

        /// <summary>
        /// Atributo requerido para expresar la fecha en la que se prestó
        /// el servicio.
        /// </summary>
        public string FechaServ { get; init; }

        /// <summary>
        /// Atributo requerido para expresar el precio del servicio (sin
        /// incluir IVA).
        /// </summary>
        public decimal PrecioServSinIva { get; init; }
    }
}
