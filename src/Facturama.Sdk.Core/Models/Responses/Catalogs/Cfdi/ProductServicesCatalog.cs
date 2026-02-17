using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Responses.Catalogs.Cfdi
{
    public sealed record ProductServicesCatalog : CatalogBase
    {
        public string IncludeIva { get; init; }
        public string IncludeIeps { get; init; }
        public string Complement { get; init; }

        public string DangerousMaterial { get; init; }
    }
}
