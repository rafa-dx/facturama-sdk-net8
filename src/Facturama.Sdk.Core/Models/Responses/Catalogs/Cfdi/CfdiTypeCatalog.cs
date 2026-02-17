using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturamaAPI.src.Facturama.Sdk.Core.Models.Responses.Catalogs.Cfdi
{
    public sealed record CfdiTypeCatalog : CatalogBase
    {
        public string Type { get; init; }
    }
}
