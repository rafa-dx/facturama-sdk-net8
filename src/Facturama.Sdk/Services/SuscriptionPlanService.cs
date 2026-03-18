using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services
{
    public sealed class SuscriptionPlanService : ISuscriptionPlanService
    {
        private string BaseEndpoint => "/api/SuscriptionPlan";

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
            _logger.LogInformation("Getting subscription plan information.");

            try
            {
                var response = await _httpClient.GetAsync<SuscriptionPlanResponse>(
                    BaseEndpoint,
                     queryParams: null,
                    cancellationToken).ConfigureAwait(false);
                _logger.LogInformation("Subscription plan information retrieved successfully.");
                return response;

            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "API error occurred while getting subscription plan information. Status Code: {StatusCode}, Error Message: {ErrorMessage}",
                    ex.StatusCode, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting subscription plan information.");
                throw;
            }
        }

    }
}
