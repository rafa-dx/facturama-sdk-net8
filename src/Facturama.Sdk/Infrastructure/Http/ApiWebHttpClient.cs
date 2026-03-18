using Facturama.Sdk.Core.Abstractions;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Infrastructure.Http
{
    public sealed class ApiWebHttpClient : FacturamaHttpClient, IApiWebHttpClient
    {
        public ApiWebHttpClient(HttpClient httpClient, ILogger<FacturamaHttpClient> logger)
        : base(httpClient, logger)
        {
        }
    }
}
