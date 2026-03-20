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
        private string BaseEndpoint => "TaxEntity";

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


            var response = await _httpClient.PutAsync<TaxEntityCsdResponse>(
            BaseEndpoint,
            request,
            cancellationToken);
            return response;

        }

        public async Task<TaxEntityCsdResponse> PutCsdFielAsync(
            TaxEntityCsdRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogInformation("Starting update of tax entity CSD FIEL for RFC: {Rfc}", request.Rfc);

            var response = await _httpClient.PutAsync<TaxEntityCsdResponse>(
            $"{BaseEndpoint}/UploadFiel",
            request,
            cancellationToken);
            return response;

        }

        public async Task<TaxEntityResponse> GetTaxEntityAsync(
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving tax entity information");

            var response = await _httpClient.GetAsync<TaxEntityResponse>(
                BaseEndpoint,
                null,
                cancellationToken);
            return response;

        }

        public async Task<TaxEntityResponse> PutTaxEntityAsync(
            TaxEntityRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);
            _logger.LogInformation("Starting update of tax entity information for RFC: {Rfc}", request.Rfc);

            var response = await _httpClient.PutAsync<TaxEntityResponse>(
            BaseEndpoint,
            request,
            cancellationToken);
            return response;

        }


        public async Task<TaxEntityLogoResponse> PutTaxEntityLogoAsync(
            TaxEntityLogoRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            _logger.LogInformation("Starting update of tax entity logo for RFC: {Rfc}", request.Image);

            var response = await _httpClient.PutAsync<TaxEntityLogoResponse>(
            $"{BaseEndpoint}/UploadLogo",
            request,
            cancellationToken);
            return response;

        }

    }

}
