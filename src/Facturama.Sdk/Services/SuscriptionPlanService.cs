using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Services
{
    internal class SuscriptionPlanService : ISuscriptionPlanService
    {
        private string BaseEndpoint => "/api/SuscriptionPlan";

        private readonly IFacturamaHttpClient _httpClient;
        private readonly ILogger<SuscriptionPlanService> _logger;

        public SuscriptionPlanService(IFacturamaHttpClient httpClient, ILogger<SuscriptionPlanService> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting subscription plan information.");
                throw;
            }
        }

    }
}
