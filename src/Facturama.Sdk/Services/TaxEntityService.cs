using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Services
{
    internal class TaxEntityService : ITaxEntityService
    {
        private string BaseEndpoint => "/api/TaxEntity";

        private readonly IApiWebHttpClient _httpClient;
        private readonly ILogger<TaxEntityService> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="TaxEntityService"/>.
        /// </summary>
        /// <param name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
        /// <param  name="logger">Logger para registrar información y errores.</param>
        public TaxEntityService(IApiWebHttpClient httpClient, ILogger<TaxEntityService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TaxEntityCsdResponse> PutCsdAsync(
            TaxEntityCsdRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogInformation("Starting update of tax entity CSD for RFC: {Rfc}", request.Rfc);

            try
            {
                var response = await _httpClient.PutAsync<TaxEntityCsdResponse>(
                BaseEndpoint,
                request,
                cancellationToken);
                return response;

            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error updating tax entity CSD for RFC: {Rfc}. Status Code: {StatusCode}, Response: {Response}",
                     request.Rfc, ex.StatusCode);
                throw;

            }
        }

        public async Task<TaxEntityCsdResponse> PutCsdFielAsync(
            TaxEntityCsdRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogInformation("Starting update of tax entity CSD FIEL for RFC: {Rfc}", request.Rfc);
            try
            {
                var response = await _httpClient.PutAsync<TaxEntityCsdResponse>(
                $"{BaseEndpoint}/UploadFiel",
                request,
                cancellationToken);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error updating tax entity CSD FIEL for RFC: {Rfc}. Status Code: {StatusCode}, Response: {Response}",
                     request.Rfc, ex.StatusCode);
                throw;
            }
        }

        public async Task<TaxEntityResponse> GetTaxEntityAsync(
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving tax entity information");
            try
            {
                var response = await _httpClient.GetAsync<TaxEntityResponse>(
                    BaseEndpoint,
                    null,
                    cancellationToken);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error retrieving tax entity information. Status Code: {StatusCode}, Response: {Response}",
                    ex.StatusCode);
                throw;
            }
        }

        public async Task<TaxEntityResponse> PutTaxEntityAsync(
            TaxEntityRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogInformation("Starting update of tax entity information for RFC: {Rfc}", request.Rfc);
            try
            {
                var response = await _httpClient.PutAsync<TaxEntityResponse>(
                BaseEndpoint,
                request,
                cancellationToken);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error updating tax entity information for RFC: {Rfc}. Status Code: {StatusCode}, Response: {Response}",
                     request.Rfc, ex.StatusCode);
                throw;
            }
        }


        public async Task<TaxEntityLogoResponse> PutTaxEntityLogoAsync(
            TaxEntityLogoRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

        _logger.LogInformation("Starting update of tax entity logo for RFC: {Rfc}", request.Image);
            try
            {
                var response = await _httpClient.PutAsync<TaxEntityLogoResponse>(
                $"{BaseEndpoint}/UploadLogo",
                request,
                cancellationToken);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(ex, "Error updating tax entity logo for RFC: {Rfc}. Status Code: {StatusCode}, Response: {Response}",
                     request.Image, ex.StatusCode);
                throw;
            }
        }


    }

}
