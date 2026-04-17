using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;

namespace Facturama.Sdk.Services;

/// <summary>
/// Service for managing branch office operations.
/// </summary>
public sealed class BranchOfficeService : IBranchOfficeService
{
    private const string BaseEndpoint = "BranchOffice";

    private readonly IApiWebHttpClient _httpClient;
    private readonly ILogger<BranchOfficeService> _logger;

    /// <summary>
    /// Inicia una nueva instancia de <see cref="BranchOfficeService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
    /// <param name="logger">Logger para registrar información y errores.</param>

    public BranchOfficeService(
            IApiWebHttpClient httpClient,
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

        _logger.LogDebug(
            "Creating a new branch office with name: {BranchOfficeName}",
            request.Name);


        var response = await _httpClient.PostAsync<BranchOfficeResponse>(
            BaseEndpoint,
            request,
            null,
            cancellationToken);

        _logger.LogInformation(
            "Successfully created branch office with name: {BranchOfficeName}",
            request.Name);

        return response;

    }

    public async Task<BranchOfficeResponse> GetByIdAsync(
        string branchOfficeId,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(branchOfficeId);

        _logger.LogDebug(
            "Retrieving branch office with ID: {BranchOfficeId}",
            branchOfficeId);

        var response = await _httpClient.GetAsync<BranchOfficeResponse>(
            $"{BaseEndpoint}/{branchOfficeId}",
               queryParams: null,
                cancellationToken);

        _logger.LogInformation(
            "Successfully retrieved branch office with ID: {BranchOfficeId}",
            branchOfficeId);

        return response;

    }

    public async Task<IReadOnlyList<BranchOfficeResponse>> ListAsync(
        CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("Retrieving all branch offices");

        var response = await _httpClient.GetAsync<List<BranchOfficeResponse>>(
            BaseEndpoint,
            queryParams: null,
            cancellationToken);

        _logger.LogInformation("Successfully retrieved all branch offices");

        return response.AsReadOnly();

    }

    public async Task DeleteAsync(
    string branchOfficeId,
    CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(branchOfficeId);

        _logger.LogDebug(
            "Deleting branch office with ID: {BranchOfficeId}",
            branchOfficeId);

        var endpoint = $"{BaseEndpoint}/{branchOfficeId}";
        await _httpClient.DeleteAsync(
            endpoint,
            cancellationToken);

        _logger.LogInformation(
            "Successfully deleted branch office with ID: {BranchOfficeId}",
            branchOfficeId);

    }

    public async Task<BranchOfficeResponse> UpdateAsync(
        string branchOfficeId,
        BranchOfficeRequest branchOfficeRequest,
        CancellationToken cancellation = default)
    {
        if(string.IsNullOrEmpty(branchOfficeId)) throw new ArgumentNullException(nameof(branchOfficeId));
        ArgumentNullException.ThrowIfNull(branchOfficeRequest);

        _logger.LogDebug(
            "Updating branch office with ID: {BranchOfficeId}",
            branchOfficeId);


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

}
