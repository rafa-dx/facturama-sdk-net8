using Facturama.Sdk.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses.Catalogs
{
    public sealed record PostalCodesCatalog : CatalogBase
    {

        public string StateCode { get; init; }
        public string MunicipalityCode { get; init; }
        public string LocationCode { get; init; }
    }
}
