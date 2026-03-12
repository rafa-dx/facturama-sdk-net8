using Facturama.Sdk.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Filters
{
    public sealed record CfdiFilter
    {
        public string keyword { get; init; }
        public string Type { get; init; }
        public string Status { get; init; } = InvoiceStatus.Active.ToString();
        public uint Page { get; init; } = uint.MinValue;
        public int FolioStart { get; init; } = -1;
        public int FolioEnd { get; init; } = -1;
        public string Rfc { get; init; }
        public string TaxEntityName { get; init; }
        public string DateStart { get; init; }= string.Empty;
        public string DateEnd { get; init; } = string.Empty;
        public string IdBranch { get; init; } = string.Empty;
        public string Serie { get; init; } = string.Empty;
        public string Id { get; init; } = string.Empty;
        public string InvoiceType { get; init; } = string.Empty;
        public string PaymentMethod { get; init; } = string.Empty;
        public string RfcIssuer { get; init; }
        public string OrderNumber { get; init; }
        //public string Folio { get; init; }
        //public string Uuid { get; init; }
        //public string RfcReceipt { get; init; }


    }
}