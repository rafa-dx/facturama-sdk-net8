using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Services
{
    internal sealed class SerieService : ISeriesService
    {
        private string BaseEndpoint => "/api/serie";

        private readonly IFacturamaHttpClient _httpClient;
        private readonly ILogger<SerieService> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="SerieService"/>.
        /// </summary>
        /// <param name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
        /// <param  name="logger">Logger para registrar información y errores.</param>
        
        public SerieService(IFacturamaHttpClient httpClient, ILogger<SerieService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<SerieResponse> CreateSerieAsync(
            string Id,
            SerieRequest request,
            CancellationToken cancellation = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Creating a new serie with name: {Name}", request.Name);

            try
            {
                var response = await _httpClient.PostAsync<SerieResponse>(
                    $"{BaseEndpoint}/{Id}", 
                    request, 
                    cancellation);
                _logger.LogInformation("Successfully created serie with Name {Name}", response.Name);
                return response;

            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new serie with name: {Name}", request.Name);
                throw;
            
            }
        }

        public async Task<IReadOnlyList<SerieResponse>> ListSerieAsync(
            string Id,
            CancellationToken cancellation = default)
        {
            _logger.LogInformation("Retrieving list of series");
            try
            {
                var response = await _httpClient.GetAsync<IReadOnlyList<SerieResponse>>(
                    $"{BaseEndpoint}/{Id}",
                    queryParams: null,
                    cancellation);
                _logger.LogInformation("Successfully retrieved list of series. Count: {Count}", response.Count);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving list of series");
                throw;
            }
        }

        public async Task<SerieResponse> DeleteSerieAsync(string Id, CancellationToken cancellation = default)
        {
            ArgumentNullException.ThrowIfNull(Id);
            _logger.LogInformation("Deleting serie with ID: {Id}", Id);
            try
            {
                var response = await _httpClient.DeleteAndResponseAsync<SerieResponse>(
                    $"{BaseEndpoint}/{Id}",
                    cancellation);
                _logger.LogInformation("Successfully deleted serie with ID: {Id}", Id);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error occurred while deleting serie with ID: {Id}", Id);
                throw;
            }
        }

    }
}
