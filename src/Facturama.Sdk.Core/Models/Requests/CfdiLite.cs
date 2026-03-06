using Facturama.Sdk.Core.Models.Cfdi;


namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record CfdiLite : CfdiBase
    {
        public string LogoUrl { get; init; }

        public Issuer Issuer { get; init; } = default!;


    }
}
