using Facturama.Sdk.Core.Models.Common;


namespace Facturama.Sdk.Core.Models.Responses.Catalogs.Cfdi
{
    public sealed record ProductServicesCatalog : CatalogBase
    {
        public string IncludeIva { get; init; }
        public string IncludeIeps { get; init; }
        public string Complement { get; init; }

        public string DangerousMaterial { get; init; }
    }
}
