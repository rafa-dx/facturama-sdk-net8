using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Requests
{
    public sealed record TaxEntityLogo
    {
        public string Image {  get; init; }

        public string Type { get; init; }
    }
}
