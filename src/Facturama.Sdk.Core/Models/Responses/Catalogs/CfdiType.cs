using Facturama.Sdk.Core.Models.Common;


namespace Facturama.Sdk.Core.Models.Responses.Catalogs
{
    public sealed record CfdiType : CatalogBase
    {
        public string NameId { get; }
    }
}
