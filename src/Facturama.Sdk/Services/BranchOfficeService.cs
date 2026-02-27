using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;

namespace Facturama.Sdk.Services;

internal sealed class BranchOfficeService : IBranchOfficeService
{
    private const string BaseEndpoint = "/api/BranchOffice";

    private readonly IFacturamaHttpClient _httpClient;
    private readonly ILogger<BranchOfficeService> _logger;

    /// <summary>
    /// Inicia una nueva instancia de <see cref="BranchOfficeService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
    /// <param name="logger">Logger para registrar información y errores.</param>

    public BranchOfficeService(
            IFacturamaHttpClient httpClient,
            ILogger<BranchOfficeService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

    public async Task<BranchOfficeResponse> CreateAsync(
        BranchOfficeRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        _logger.LogInformation(
            "Creating a new branch office with name: {BranchOfficeName}",
            request.Name);

        try
        {
            var response = await _httpClient.PostAsync<BranchOfficeResponse>(
                BaseEndpoint,
                request,
                cancellationToken);
            _logger.LogInformation(
                "Successfully created branch office with name: {BranchOfficeName}",
                request.Name);
            return response;

        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while creating product with name: {ProductName}",
                request.Name);
            throw;
        }
    }

    public async Task<BranchOfficeResponse> GetByIdAsync(
        string branchOfficeId,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(branchOfficeId);
        _logger.LogInformation(
            "Retrieving branch office with ID: {BranchOfficeId}",
            branchOfficeId);
        try
        {
            var response = await _httpClient.GetAsync<BranchOfficeResponse>(
                $"{BaseEndpoint}/{branchOfficeId}",
                   queryParams: null,
                    cancellationToken);

            _logger.LogInformation(
                "Successfully retrieved branch office with ID: {BranchOfficeId}",
                branchOfficeId);
            return response;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while retrieving branch office with ID: {BranchOfficeId}",
                branchOfficeId);
            throw;
        }
    }

    public async Task<IReadOnlyList<BranchOfficeResponse>> ListAsync(
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Retrieving all branch offices");
        try
        {
            var response = await _httpClient.GetAsync<List<BranchOfficeResponse>>(
                BaseEndpoint,
                queryParams: null,
                cancellationToken);
            _logger.LogInformation("Successfully retrieved all branch offices");
            return response.AsReadOnly();
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all branch offices");
            throw;
        }
    }

    public async Task DeleteAsync(
    string branchOfficeId,
    CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(branchOfficeId);

        _logger.LogInformation(
            "Deleting branch office with ID: {BranchOfficeId}",
            branchOfficeId);
        try
        {
            var endpoint = $"{BaseEndpoint}/{branchOfficeId}";
            await _httpClient.DeleteAsync(
                endpoint,
                cancellationToken);

            _logger.LogInformation(
                "Successfully deleted branch office with ID: {BranchOfficeId}",
                branchOfficeId);
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while deleting branch office with ID: {BranchOfficeId}",
                branchOfficeId);
            throw;
        }
    }

    public async Task<BranchOfficeResponse> UpdateAsync(
        string branchOfficeId,
        BranchOfficeRequest branchOfficeRequest,
        CancellationToken  cancellation =   default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(branchOfficeId);
        ArgumentNullException.ThrowIfNull(branchOfficeRequest);

        _logger.LogInformation(
            "Updating branch office with ID: {BranchOfficeId}",
            branchOfficeId);

        try
        {
            var endpoint = $"{BaseEndpoint}/{branchOfficeId}";
            var response = await _httpClient.PutAsync<BranchOfficeResponse>(
                endpoint,
                branchOfficeRequest,
                cancellation);

            _logger.LogInformation(
                "Successfully updated branch office with ID: {BranchOfficeId}",
                branchOfficeId);
            return response;

        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while updating branch office with ID: {BranchOfficeId}",
                branchOfficeId);
            throw;
        }

    }

}
