using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services
{
    public sealed class SuscriptionPlanService : ISuscriptionPlanService
    {
        private string BaseEndpoint => "SuscriptionPlan";

        private readonly IApiWebHttpClient _httpClient;
        private readonly ILogger<SuscriptionPlanService> _logger;

        public SuscriptionPlanService(IApiWebHttpClient httpClient, ILogger<SuscriptionPlanService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<SuscriptionPlanResponse> GetAsync(
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("Getting subscription plan information.");


            var response = await _httpClient.GetAsync<SuscriptionPlanResponse>(
                BaseEndpoint,
                queryParams: null,
                cancellationToken).ConfigureAwait(false);

            _logger.LogInformation("Subscription plan information retrieved successfully.");

            return response;

        }

    }
}
