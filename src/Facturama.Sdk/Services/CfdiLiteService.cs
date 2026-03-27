using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Responses;
using Facturama.Sdk.Core.Utilities;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services
{
    public sealed class CfdiLiteService : ICfdiLiteService
    {
        private int DefaultAPIVersion = 3;
        private const string BaseEndpoint = "cfdis";

        // private readonly IFacturamaHttpClient _httpClient;
        private readonly IApiLiteHttpClient _httpClient;
        private readonly ILogger<CfdiLiteService> _logger;

        public CfdiLiteService(
            IApiLiteHttpClient httpClient,
            ILogger<CfdiLiteService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region CREATE - Creación de CFDIs
        public async Task<CfdiResponse> CreateAsync(
            CfdiLiteRequest request,
            int? version = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            _logger.LogInformation(
            "Creating CFDI 4.0 for receiver: {ReceiverRfc}",
            request.Receiver?.Rfc ?? "N/A");
            var apiVersion = version ?? DefaultAPIVersion;

            var endpoint = $"{apiVersion}/{BaseEndpoint}";

            _logger.LogInformation("Creating CFDI with API version {ApiVersion}", apiVersion);

            var response = await _httpClient.PostAsync<CfdiResponse>(
            endpoint,
            request,
            null,
            cancellationToken);
            _logger.LogInformation(
                "CFDI created successfully. Version: {ApiVersion}",
                apiVersion);

            return response;


        }
        #endregion

        #region Consultar CFDI por ID
        /// <inheritdoc/>
        public async Task<CfdiResponse> GetAsync(
            string cfdiId,
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiId);

            _logger.LogDebug("Retrieving CFDI with ID: {CfdiId}", cfdiId);

            var queryParams =
                new Dictionary<string, string?>
                {
                    ["type"] = "issuedLite"
                };
            var endpoint = $"cfdis/{cfdiId}";

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
                "/cfdi",
                queryParams,
                cancellationToken);

            _logger.LogInformation("Retrieved {Count} CFDIs", response.Count);

            return response.AsReadOnly();

        }
        #endregion

        #region Operaciones especiales de CFDI
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
            string cfdiType,
            string cfdiId,
            CancellationToken cancellationToken = default)
        {

            ArgumentException.ThrowIfNullOrWhiteSpace(fileType);
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiType);
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiId);

            _logger.LogInformation(
               "Downloading CFDI file. Type: {FileType}, CFDI: {CfdiId}",
               fileType,
               cfdiId);

            var endpoint = $"/cfdi/{fileType}/{cfdiType}/{cfdiId}";
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
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiId);
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiType);

            _logger.LogInformation(
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
                $"/cfdi/{cfdiId}",
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
            string issuerEmail,
            string? subject = null,
            string? comments = null,
            string cfdiType = "issuedLite",
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiId);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            ArgumentException.ThrowIfNullOrWhiteSpace(issuerEmail);
            ArgumentException.ThrowIfNullOrWhiteSpace(cfdiType);

            _logger.LogInformation(
                "Sending CFDI {CfdiId} to {Email} (Multiemisor from {IssuerEmail})",
                cfdiId,
                email,
                issuerEmail);

            var queryParams = new Dictionary<string, string?>
            {
                ["cfdiType"] = cfdiType,
                ["cfdiId"] = cfdiId,
                ["email"] = email,
                ["issuerEmail"] = issuerEmail
            };

            if (!string.IsNullOrWhiteSpace(subject))
                queryParams["subject"] = subject;

            if (!string.IsNullOrWhiteSpace(comments))
                queryParams["comments"] = comments;

            var endpoint = "/Cfdi";

            var response = await _httpClient.PostAsync<CfdiSendResponse>(
                endpoint,
                new { }, // Body vacío
                queryParams,
                cancellationToken);

            _logger.LogInformation(
                "CFDI {CfdiId} sent successfully to {Email} from {IssuerEmail}",
                cfdiId,
                email,
                issuerEmail);

            return response;

        }
        #endregion

        public async Task<CsdResponse> UploadCsdAsync(
            CsdRequest csd,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(csd);

            _logger.LogInformation(
                "Uploading CSD for RFC: {Rfc}",
                csd.Rfc);

            var response = await _httpClient.PostAsync<CsdResponse>(
                "csds",
                csd,
                null,
                cancellationToken);

            _logger.LogInformation(
                "CSD uploaded successfully for RFC: {Rfc}",
                csd.Rfc);

            return response;

        }

        public async Task<CsdResponse> GetCsdAsync(
            string rfc,
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(rfc);
            _logger.LogInformation(
                "Retrieving CSD for RFC: {Rfc}",
                rfc);

            var response = await _httpClient.GetAsync<CsdResponse>(
                $"csds/{rfc}",
                null,
                cancellationToken);
            _logger.LogInformation(
                "CSD retrieved successfully for RFC: {Rfc}",
                rfc);
            return response;
        }

        public async Task<CsdResponse> DeleteCsdAsync(
            string rfc,
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(rfc);
            _logger.LogInformation(
                "Deleting CSD for RFC: {Rfc}",
                rfc);

            var response = await _httpClient.DeleteAndResponseAsync<CsdResponse>(
                $"csds/{rfc}",
                null,
                cancellationToken);
            _logger.LogInformation(
                "CSD deleted successfully for RFC: {Rfc}",
                rfc);
            return response;
        }

        public async Task<IReadOnlyList<CsdResponse>> ListCsdAsync(
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Listing all CSDs");

            var response = await _httpClient.GetAsync<List<CsdResponse>>(
                "csds",
                null,
                cancellationToken);
            _logger.LogInformation("Retrieved {Count} CSDs", response.Count);
            return response.AsReadOnly();
        }

        public async Task<CsdResponse> UpdateCsdAsync(
            string rfc,
            CsdRequest csd,
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(rfc);
            ArgumentNullException.ThrowIfNull(csd);
            _logger.LogInformation(
                "Updating CSD for RFC: {Rfc}",
                rfc);
            var response = await _httpClient.PutAsync<CsdResponse>(
                $"csds/{rfc}",
                csd,
                cancellationToken);
            _logger.LogInformation(
                "CSD updated successfully for RFC: {Rfc}",
                rfc);
            return response;
        }
    }
}
