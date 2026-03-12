using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record TaxEntityLogoResponse
    {
        public string Image {  get; init; }

        public string Message { get; init; }
    }
}
