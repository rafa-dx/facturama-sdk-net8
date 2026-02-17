using Facturama.Sdk.Core.Models.Common;


namespace Facturama.Sdk.Core.Models.Responses.Catalogs.Cfdi
{
    public sealed record CfdiTypeCatalog : CatalogBase
    {
        public string Type { get; init; }
    }
}
