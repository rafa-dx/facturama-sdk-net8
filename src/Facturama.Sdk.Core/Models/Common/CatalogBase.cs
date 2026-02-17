using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Facturama.Sdk.Core.Models.Common
{
    public abstract record CatalogBase
    {
        public string Name { get; init; }

        public string Value { get; init; }
    }
}

