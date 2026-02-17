using Facturama.Sdk.Core.Models.Cfdi;

using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Complements.ForeignTrade
{
    public sealed record ForeignTradeComplement
    {
        /// <summary>
        /// Emisor del complemento de comercio exterior
        /// </summary>
        [JsonPropertyName("Issuer")]
        public Issuer Issuer { get; init; }

        /// <summary>
        /// Receptor del complemento de comercio exterior
        /// </summary>
        [JsonPropertyName("Receiver")]
        public Receiver Receiver { get; init; }


        /// <summary>
        /// Datos del o los propietarios de la mecancía que se tarslada
        /// </summary>
        [JsonPropertyName("Owner")]
        public List<Owner> Owner { get; init; }

        /// <summary>
        /// Destinatario, datos complementarios del destinatario.
        /// </summary>
        [JsonPropertyName("Recipient")]
        public List<Recipient> Recipient { get; init; }

        /// <summary>
        /// Motivo Traslado
        /// </summary>
        [JsonPropertyName("ReasonForTrasnfer")]
        public string ReasonForTrasnfer { get; init; }


        /// <summary>
        /// Informacion de las mercancias que se trasladan
        /// </summary>
        [JsonPropertyName("Commodity")]
        public List<Commodity> Commodity { get; init; }


        /// <summary>
        /// clave de pedimento que se haya declarado conforme al catálogo
        /// </summary>
        [JsonPropertyName("RequestCode")]
        public string RequestCode { get; init; }


        /// <summary>
        /// Excepción de certificados de Origen de los Tratados de Libre Comercio.
        [JsonPropertyName("OriginCertificate")]
        public bool? OriginCertificate { get; init; }


        /// <summary>
        /// Folio del certificado de origen o el folio fiscal del CFDI con el que se pagó la expedición del certificado de origen.
        /// </summary>
        [JsonPropertyName("OriginCertificateNumber")]
        public string OriginCertificateNumber { get; init; }


        /// <summary>
        /// Número Exportador Confiable.
        /// </summary>
        [JsonPropertyName("ReliableExporterNumber")]
        public string ReliableExporterNumber { get; init; }


        /// <summary>
        ///  clave del INCOTERM aplicable a la factura.
        /// </summary>
        [JsonPropertyName("Incoterm")]
        public string Incoterm { get; init; }

        /// <summary>
        /// Información adicional.
        /// </summary>
        [JsonPropertyName("Observations")]
        public string Observations { get; init; }

        /// <summary>
        /// Tipo de Cambio USD, valor en pesos mexicanos que equivalen a un dólar de Estados Unidos de América
        /// </summary>
        [JsonPropertyName("ExchangeRateUSD")]
        public decimal? ExchangeRateUSD { get; init; }


        /// <summary>
        /// Total USD, importe total en dolares (USD)
        /// </summary>
        [JsonPropertyName("TotalUSD")]
        public decimal? TotalUSD { get; init; }
    }
}
