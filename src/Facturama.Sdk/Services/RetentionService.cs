using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Responses;
using Facturama.Sdk.Core.Utilities;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services
{
    public class RetentionService : IRetentionService
    {
        private int DefaultAPIVersion = 2;
        private const string BaseEndpoint = "retenciones";

        private readonly IApiRetentionHttpClient _httpClient;
        private readonly ILogger<RetentionService> _logger;

        ///<summary>
        ///Inicializa una nueva instancia de <see cref="RetentionService"/>
        ///</summary>
        /// <param name="httpClient">Cliente HTTP de Facturama.</param>
        /// <param name="logger">Logger para diagnósticos.</param>
        /// 
        public RetentionService(
            IApiRetentionHttpClient httpClient,
            ILogger<RetentionService> logger )
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region CREATE 
        public async Task<RetentionResponse> CreateAsync(
            RetentionRequest request,
            CancellationToken cancellationToken )
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            _logger.LogInformation("Creating retention from...", request.Emisor.RFCEmisor);

            var endpoint = $"{DefaultAPIVersion}/{BaseEndpoint}";

            _logger.LogInformation("Creating retention with version {ApiVersion}", DefaultAPIVersion);

            var response = await _httpClient.PostAsync<RetentionResponse>(
                endpoint,
                request,
                null, cancellationToken );

            return response;
        }
        #endregion

        #region Consultar retencion
        public async Task<RetentionResponse> GetAsync(
            string cfdiId,
            CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }

            _logger.LogDebug("Retrieving Retentionwith ID {CfdiId}", cfdiId);

            var endpoint = $"{BaseEndpoint}/{cfdiId}";

            var response = await _httpClient.GetAsync<RetentionResponse>(
                endpoint,
                null,
                cancellationToken);


            _logger.LogDebug(
                "Retention retrieved successfully: {CfdiId}",
                cfdiId);

            return response;
        }

        #endregion

        #region
        public async Task<IReadOnlyList< ListCfdiResponse>> ListAsync(
            RetentionFilter? filter,
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug(
                "Listing retewntion with filter: {HasFilter}",
                filter != null);


            var queryParams = filter != null
               ? QueryBuilder.FromObject(filter)
               : null;

            var response = await _httpClient.GetAsync<List<ListCfdiResponse>>(
                BaseEndpoint,
                queryParams,
                cancellationToken);

            _logger.LogDebug("Retrieved {Count} CFDIs", response.Count);

            return response.AsReadOnly();
        }
        #endregion

        #region
        public async Task<CfdiDownloadResponse> DownloadFileAsync(
            string cfdiId,
            string format,
            CancellationToken cancellationToken = default)
        {

            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }
            if(string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentException("Format cannot be null or whitespace.", nameof(format));
            }

            _logger.LogInformation(
               "Downloading CFDI file. Type: {FileType}, CFDI: {CfdiId}",
               format,
               cfdiId);

            var endpoint = $"{BaseEndpoint}/{cfdiId}/{format}";

            var response = await _httpClient.GetAsync<CfdiDownloadResponse>(
                endpoint,
                null,
                cancellationToken
                );
            return response;
        }
        #endregion



        #region
        public async Task<CfdiCancellationResponse> CancelAsync(
            string cfdiId,
            string? motive = null,
            string? uuidReplacement = null, 
            CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }

            _logger.LogInformation(
                "Cancelling CFDI: {CfdiId}, Type: retention, Motive: {Motive}",
                cfdiId,
                motive ?? "None", uuidReplacement ?? "None");

            var queryParams = new Dictionary<string, string?>
            {
                ["motive"] = motive,
                ["uuidReplacement"] = uuidReplacement
            };

            var endpoint = $"{BaseEndpoint}/{cfdiId}";

            var response = await _httpClient.DeleteAndResponseAsync<CfdiCancellationResponse>(
               endpoint,
               queryParams,
               cancellationToken);

            _logger.LogInformation(
                "CFDI cancelled successfully: {CfdiId}",
                cfdiId);

            return response;
        }
        #endregion


        #region
        public async Task<CfdiSendResponse> SendByEmailAsync(
            string cfdiId,
            string email,
            CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));
            }

            _logger.LogInformation(
                "Sending CFDI {CfdiId} to {Email}",
                cfdiId,
                email);

            var queryParams = new Dictionary<string, string?>
            {
                ["id"] = cfdiId,
                ["email"] = email
            };

            var response = await _httpClient.PostAsync<CfdiSendResponse>(
                $"{ BaseEndpoint}/envia",
                new { },
                queryParams,
                cancellationToken);

            return response;
        }
        #endregion


    }
}
