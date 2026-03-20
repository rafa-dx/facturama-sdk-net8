using Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount;
using Facturama.Sdk.Core.Models.Complements.EducationalInstitution;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed class ItemComplement
    {
        [JsonPropertyName("EducationalInstitution")]
        public EducationalInstitutionComplement? EducationalInstitution { get; set; }

        [JsonPropertyName("ThirdPartyAccount")]
        public ThirdPartyAccountComplement? ThirdPartyAccount { get; set; }


    }
}
