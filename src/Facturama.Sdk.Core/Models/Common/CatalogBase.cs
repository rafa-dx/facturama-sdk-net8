namespace Facturama.Sdk.Core.Models.Common
{
    public abstract record CatalogBase
    {
        public string Name { get; init; }

        public string Value { get; init; }

        public string Description { get; init; }
    }
}

