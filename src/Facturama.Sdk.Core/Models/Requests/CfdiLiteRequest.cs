using Facturama.Sdk.Core.Models.Cfdi;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record CfdiLiteRequest : CfdiBase
    {
        public string LogoUrl { get; set; }

        public Issuer Issuer { get; set; } = default!;


    }
}
