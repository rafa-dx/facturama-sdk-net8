using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Retentions.Complements
{
    public sealed record ServiciosPlataformasTecnologicas
    {
        /// <summary>
		/// Nodo requerido para detallar la información de los servicios prestados por
		/// personas físicas que utilicen plataformas tecnológicas.
		/// </summary>
		public List<DetallesDelServicio> Servicios { get; init; }

        /// <summary>
        /// Atributo requerido para especificar el periodo de retención.
        /// </summary>
        public string Periodicidad { get; init; }

        /// <summary>
        /// Atributo requerido para expresar el número de servicios realizados en el periodo.
        /// </summary>
        public int NumServ { get; init; }

        /// <summary>
        /// Atributo requerido para expresar monto total de los servicios realizados en el periodo, sin incluir el monto del IVA.
        /// </summary>
        public decimal MontToServSIva { get; init; }

        /// <summary>
        /// Atributo requerido para expresar monto total del IVA trasladado por los servicios realizados en el periodo.
        /// </summary>
        public decimal TotalIvaTrasladado { get; init; }

        /// <summary>
        /// Atributo requerido para expresar monto total del IVA retenido por los servicios realizados en el periodo.
        /// </summary>
        public decimal TotalIvaRetenido { get; init; }

        /// <summary>
        /// Atributo requerido para expresar monto total del ISR retenido por los servicios realizados en el periodo.
        /// </summary>
        public decimal TotalIsrRetenido { get; init; }

        /// <summary>
        /// Atributo requerido para expresar la diferencia del IVA entregado al prestador del servicio en el periodo.
        /// </summary>
        public decimal DifIvaEntregadoPrestServ { get; init; }

        /// <summary>
        /// Atributo requerido para expresar el monto total cobrado al
        /// prestador del servicio por el uso de la plataforma en el periodo.
        /// </summary>
        public decimal MonTotalporUsoPlataforma { get; init; }

        /// <summary>
        /// Atributo condicional para expresar la suma de los atributos
        /// “ImpContrib“ del nodo hijo “ContribucionGubernamental” del
        ///	periodo que corresponda.
        /// </summary>
        public decimal? MonTotalContribucionGubernamental { get; init; }
    }
}
