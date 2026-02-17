using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Complements.EducationalInstitution
{
    public sealed record EducationalInstitutionComplement
    {
        /// <summary>
        /// Nombre del alumno
        /// </summary>
        [JsonPropertyName("StudentsName")]
        public string StudentsName { get; set; }

        /// <summary>
        /// Clave única de registro de población del alumno
        /// </summary>        
        [JsonPropertyName("Curp")]
        public string Curp { get; set; }

        /// <summary>
        /// Debe ser alguno de los siguientes:
        /// Preescolar|Primaria|Secundaria|Profesional técnico|Bachillerato o su equivalente
        /// </summary>
        [JsonPropertyName("EducationLevel")]
        public string EducationLevel { get; set; }

        /// <summary>
        /// Clave del centro de trabajo o el reconocimiento de validez oficial de esudios que tenga la instución educativa privada donde se realiza el pago
        /// </summary>
        [JsonPropertyName("AutRvoe")]
        public string AutRvoe { get; set; }

        /// <summary>
        /// RFC de quien realiza el pago cuando sea diferente a quien recibe el servicio (opcional)
        /// </summary>
        [JsonPropertyName("PaymentRfc")]
        public string PaymentRfc { get; set; }
    }
}
