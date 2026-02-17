using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Complements.EducationalInstitution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record ItemComplement
    {
        [JsonPropertyName("EducationalInstitution")]
        public EducationalInstitutionComplement? EducationalInstitution { get; init; }

        [JsonPropertyName("ThirdPartyAccount")]
        public ThirdPartyAccountComplement? ThirdPartyAccount { get; init; }


    }
}
