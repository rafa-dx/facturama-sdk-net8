using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record CfdiDownloadResponse
    {
        public string ContentEncoding { get; init; }
        public string ContentType { get; init; }
        public int ContentLength { get; init; }

        [JsonPropertyName("Content")]
        public string ContentBase64 { get; set; }

        [JsonIgnore]
        public byte[] ContentBytes => Convert.FromBase64String(ContentBase64);


    }
}
