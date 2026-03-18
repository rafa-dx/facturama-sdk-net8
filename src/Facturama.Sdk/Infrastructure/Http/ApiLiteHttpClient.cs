using Facturama.Sdk.Core.Abstractions;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Infrastructure.Http
{
    public sealed class ApiLiteHttpClient : FacturamaHttpClient, IApiLiteHttpClient
    {
        public ApiLiteHttpClient(HttpClient httpClient, ILogger<FacturamaHttpClient> logger)
            : base(httpClient, logger)
        {
        }
    }
}
