using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Filters
{
    public sealed record RetentionFilter
    {
        public string keyword { get; init; }

        public string status { get; init; }
    }
}
