using Facturama.Sdk;
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Facturama.Sdk.Core.Utilities;
using Microsoft.Extensions.Logging;

namespace FacturamaAPI.src.Facturama.Sdk.Services
{
    public sealed class CfdiService : ICfdiService
    {
        private int DefaultAPIVersion = 3;
        private const string BaseEndpoint = "cfdis";


        //private readonly IFacturamaHttpClient _httpClient;
        private readonly IApiWebHttpClient _httpClient;
        private readonly ILogger<CfdiService> _logger;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CfdiService"/>.
        /// </summary>
        /// <param name="httpClient">Cliente HTTP de Facturama.</param>
        /// <param name="logger">Logger para diagnósticos.</param>
        public CfdiService(
            IApiWebHttpClient httpClient,
            ILogger<CfdiService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        #region CREATE - Creación de CFDIs
        public async Task<CfdiResponse> CreateAsync(
            CfdiRequest request,

            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            _logger.LogDebug(
            "Creating CFDI 4.0 for receiver: {ReceiverRfc}",
            request.Receiver?.Rfc ?? "N/A");


            var endpoint = $"{DefaultAPIVersion}/{BaseEndpoint}";

            _logger.LogInformation("Creating CFDI with API version {ApiVersion}", DefaultAPIVersion);

            var response = await _httpClient.PostAsync<CfdiResponse>(
            endpoint,
            request,
            null,
            cancellationToken);
            _logger.LogInformation(
                "CFDI created successfully. Version: {ApiVersion}",
                DefaultAPIVersion);

            return response;


        }
        #endregion

        #region Consultar CFDI por ID
        /// <inheritdoc/>
        public async Task<CfdiResponse> GetAsync(
            string cfdiId,
            CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }

            _logger.LogDebug("Retrieving CFDI with ID: {CfdiId}", cfdiId);


            var queryParams =
                new Dictionary<string, string?>
                {
                    ["type"] = "issued"
                };
            var endpoint = $"cfdi/{cfdiId}";

            var response = await _httpClient.GetAsync<CfdiResponse>(
                endpoint,
                queryParams,
                cancellationToken);

            _logger.LogInformation(
                "CFDI retrieved successfully: {CfdiId}",
                cfdiId);

            return response;

        }
        #endregion

        #region Listar Facturas
        /// <inheritdoc/>
        public async Task<IReadOnlyList<ListCfdiResponse>> ListAsync(
            CfdiFilter? filter = null,
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug(
                "Listing CFDIs with filter: {HasFilter}",
                filter != null);

            var queryParams = filter != null
                ? QueryBuilder.FromObject(filter)
                : null;

            var response = await _httpClient.GetAsync<List<ListCfdiResponse>>(
                "cfdi",
                queryParams,
                cancellationToken);

            _logger.LogInformation("Retrieved {Count} CFDIs", response.Count);

            return response.AsReadOnly();

        }
        #endregion

        #region Estado CFDI SAT

        /// <inheritdoc/>
        public async Task<CfdiStatusResponse> GetStatusAsync(
            CfdiStatusParams filter,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(filter);

            _logger.LogDebug(
                "Retrieving CFDI status for UUID: {Uuid}",
                filter.Uuid);


            var queryParams = QueryBuilder.FromObject(filter);

            var response = await _httpClient.GetAsync<CfdiStatusResponse>(
                "cfdi/status",
                queryParams,
                cancellationToken);

            _logger.LogInformation(
               "Status retrieved for UUID: {Uuid} - Status: {Status}",
               filter.Uuid,
               response.Status);

            return response;

        }
        #endregion

        #region Descarga de CFDI
        /// <inheritdoc/>
        public async Task<CfdiDownloadResponse> DownloadFileAsync(
            string fileType,
            string format,
            string cfdiId,
            CancellationToken cancellationToken = default)
        {

            if(string.IsNullOrWhiteSpace(fileType))
            {
                throw new ArgumentException("File type cannot be null or whitespace.", nameof(fileType));
            }
            if(string.IsNullOrWhiteSpace(format))
            {
                throw new ArgumentException("Format cannot be null or whitespace.", nameof(format));
            }
            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }

            _logger.LogDebug(
               "Downloading CFDI file. Type: {FileType}, CFDI: {CfdiId}",
               fileType,
               cfdiId);

            var endpoint = $"cfdi/{fileType}/{format}/{cfdiId}";
            var response = await _httpClient.GetAsync<CfdiDownloadResponse>(
                endpoint,
                null,
                cancellationToken);

            _logger.LogInformation(
                "CFDI file downloaded successfully: {CfdiId}",
                cfdiId);

            return response;

        }

        #endregion

        #region Cancelación de CFDI
        /// <inheritdoc/>
        public async Task<CfdiCancellationResponse> CancelAsync(
            string cfdiId,
            string cfdiType,
            string? motive = null,
            string? uuidReplacement = null,
            CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrWhiteSpace(cfdiId))
            {
                throw new ArgumentException("CFDI ID cannot be null or whitespace.", nameof(cfdiId));
            }
            if(string.IsNullOrWhiteSpace(cfdiType))
            {
                throw new ArgumentException("CFDI type cannot be null or whitespace.", nameof(cfdiType));
            }

            _logger.LogDebug(
                "Cancelling CFDI: {CfdiId}, Type: {CfdiType}, Motive: {Motive}",
                cfdiId,
                cfdiType,
                motive ?? "None");

            var queryParams = new Dictionary<string, string?>
            {
                ["type"] = cfdiType,
                ["motive"] = motive,
                ["uuidReplacement"] = uuidReplacement
            };

            var response = await _httpClient.DeleteAndResponseAsync<CfdiCancellationResponse>(
                $"cfdi/{cfdiId}",
                queryParams,
                cancellationToken);

            _logger.LogInformation(
                "CFDI cancelled successfully: {CfdiId}",
                cfdiId);

            return response;

        }
        #endregion

        #region Envío de CFDI por correo electrónico

        /// <inheritdoc/>
        public async Task<CfdiSendResponse> SendByEmailAsync(
            string cfdiId,
            string email,
            string cfdiType = "issued",
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
            if(string.IsNullOrWhiteSpace(cfdiType))
            {
                throw new ArgumentException("CFDI type cannot be null or whitespace.", nameof(cfdiType));
            }

            _logger.LogDebug(
                "Sending CFDI {CfdiId} to {Email}",
                cfdiId,
                email);

            var queryParams = new Dictionary<string, string?>
            {
                ["cfdiType"] = cfdiType,
                ["cfdiId"] = cfdiId,
                ["email"] = email
            };


            var response = await _httpClient.PostAsync<CfdiSendResponse>(
                "Cfdi",
                new { }, // Body vacío
                queryParams,
                cancellationToken);

            _logger.LogInformation(
                "CFDI {CfdiId} sent successfully to {Email}",
                cfdiId,
                email);

            return response;

        }
        #endregion

    }

}
