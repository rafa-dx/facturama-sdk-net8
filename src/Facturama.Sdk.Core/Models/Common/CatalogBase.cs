namespace Facturama.Sdk.Core.Models.Common
{
    public abstract record CatalogBase
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}

