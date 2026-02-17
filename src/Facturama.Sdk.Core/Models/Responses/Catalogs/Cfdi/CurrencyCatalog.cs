using Facturama.Sdk.Core.Models.Common;


namespace Facturama.Sdk.Core.Models.Responses.Catalogs.Cfdi
{
    public sealed record CurrencyCatalog : CatalogBase
    {
        public decimal Decimals { get; init; }
        public decimal PrecisionRate { get; init; }
    }
}
