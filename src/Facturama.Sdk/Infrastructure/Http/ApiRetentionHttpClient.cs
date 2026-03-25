using Facturama.Sdk.Core.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Infrastructure.Http
{
    public sealed class ApiRetentionHttpClient : FacturamaHttpClient, IApiRetentionHttpClient
    {
        public ApiRetentionHttpClient(HttpClient httpClient, ILogger<FacturamaHttpClient> logger)
        : base(httpClient, logger)
        {
        }
    }

}
