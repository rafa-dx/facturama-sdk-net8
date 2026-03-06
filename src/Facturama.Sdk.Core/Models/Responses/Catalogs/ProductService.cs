using Facturama.Sdk.Core.Models.Common;


namespace Facturama.Sdk.Core.Models.Responses.Catalogs
{
    public sealed record ProductServicesCatalogs : CatalogBase
    {
        public string IncludeIva { get;  }
        public string IncludeIeps { get;  }
        public string Complement { get;  }

        public string DangerousMaterial { get;  }
    }
}
