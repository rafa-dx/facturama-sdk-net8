using Facturama.Sdk.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Filters
{
    public sealed record CfdiStatusFilter
    {
        [QueryName("uuid")]
        public string Uuid { get; init; }

        [QueryName("issuerRfc")]
        public string IssuerRfc { get; init; }

        [QueryName("receiverRfc")]
        public string ReceiverRfc { get; init; }

        [QueryName("total")]
        public string Total { get; init; }

    }
}
