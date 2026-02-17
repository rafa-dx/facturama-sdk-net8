using Facturama.Sdk.Core.Models.Complements.ThirdPartyAccount;
using Facturama.Sdk.Core.Models.Complements.EducationalInstitution;
using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Cfdi
{
    public sealed record ItemComplement
    {
        [JsonPropertyName("EducationalInstitution")]
        public EducationalInstitutionComplement? EducationalInstitution { get; init; }

        [JsonPropertyName("ThirdPartyAccount")]
        public ThirdPartyAccountComplement? ThirdPartyAccount { get; init; }


    }
}
