using System.Runtime.Serialization;


namespace Facturama.Sdk.Core.Enums
{
    public enum CfdiType
    {
        [EnumMember(Value = "I")]
        Ingreso,

        [EnumMember(Value = "E")]
        Egreso,

        [EnumMember(Value = "T")]
        Traslado,

        [EnumMember(Value = "P")]
        Pago,

        [EnumMember(Value = "N")]
        Nomina
    }

    public enum  FileFormat
    {
        Xml, Pdf, Html
    }

    public enum InvoiceType
    {
        Issued, Received, Payroll
    }

    public enum InvoiceStatus
    {
        all, Active, Cancelled
    }

}
