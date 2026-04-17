
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;

namespace Facturama.Sdk.Services;

/// <summary>
/// Implementación del servicio de gestión de clientes de Facturama.
/// </summary>
public sealed class ClientService : IClientService
{
    private const string BaseEndpoint = "client";
    private const string BaseEndpointPaginated = "Clients";
    private const int MaxPageLength = 100;

    private readonly IApiWebHttpClient _httpClient;
    private readonly ILogger<ClientService> _logger;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="ClientService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP de Facturama.</param>
    /// <param name="logger">Logger para diagnósticos.</param>
    public ClientService(
        IApiWebHttpClient httpClient,
        ILogger<ClientService> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public async Task<ClientResponse> CreateAsync(
        ClientRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);
        ValidateCreateRequest(request);

        _logger.LogDebug(
            "Creating client with RFC: {Rfc}",
            request.Rfc);


        var response = await _httpClient.PostAsync<ClientResponse>(
            BaseEndpoint,
            request,
            null,
            cancellationToken);

        _logger.LogInformation(
            "Client created successfully with ID: {ClientId}, RFC: {Rfc}",
            response.Id,
            response.Rfc);

        return response;
    }

    /// <inheritdoc/>
    public async Task<ClientResponse> GetAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        if(string.IsNullOrWhiteSpace(clientId))
        {
            throw new ArgumentException("Client ID cannot be null or whitespace.", nameof(clientId));
        }

        _logger.LogDebug("Retrieving client with ID: {ClientId}", clientId);


        var endpoint = $"{BaseEndpoint}/{clientId}";
        var response = await _httpClient.GetAsync<ClientResponse>(
            endpoint,
            queryParams: null,
            cancellationToken);

        _logger.LogInformation(
            "Client retrieved successfully: {ClientId} - {Rfc}",
            response.Id,
            response.Rfc);

        return response;


    }


    /// <inheritdoc/>
    public async Task<IReadOnlyList<ClientResponse>> ListAsync(
        string? rfc = null,
    CancellationToken cancellationToken = default)
    {

        _logger.LogDebug("Retrieving all clients (no pagination)");


        var queryParams = string.IsNullOrEmpty(rfc) ? null :
            new Dictionary<string, string?>
            {
                ["keyword"] = rfc
            };
        var response = await _httpClient.GetAsync<List<ClientResponse>>(
            BaseEndpoint,
            queryParams,
            cancellationToken);

        _logger.LogInformation(
            "Retrieved {Count} clients",
            response.Count);

        return response.AsReadOnly();
    }
    /// <inheritdoc/>
    public async Task<PaginatedResponse<ClientResponse>> ListPaginatedAsync(
        int start = 0,
        int length = 100,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        ValidatePaginationParameters(start, length);

        _logger.LogDebug(
            "Retrieving clients with pagination: start={Start}, length={Length}, search={Search}",
            start,
            length,
            search ?? "(none)");


        var queryParams = new Dictionary<string, string?>
        {
            ["start"] = start.ToString(),
            ["length"] = length.ToString()
        };

        if (!string.IsNullOrWhiteSpace(search))
        {
            queryParams["search"] = search;
        }

        var response = await _httpClient.GetAsync<PaginatedResponse<ClientResponse>>(
            BaseEndpointPaginated,
            queryParams,
            cancellationToken);

        _logger.LogInformation(
            "Retrieved {Count} of {Total} clients",
            response.recordsFiltered,
            response.recordsTotal);

        return response;

    }

    /// <inheritdoc/>
    public async Task<ClientResponse> UpdateAsync(
        string clientId,
        ClientRequest request,
        CancellationToken cancellationToken = default)
    {
        if(string.IsNullOrWhiteSpace(clientId))
        {
            throw new ArgumentException("Client ID cannot be null or whitespace.", nameof(clientId));
        }
        ArgumentNullException.ThrowIfNull(request);
        ValidateUpdateRequest(request);

        _logger.LogDebug(
            "Updating client with ID: {ClientId}",
            clientId);

        var endpoint = $"{BaseEndpoint}/{clientId}";
        var response = await _httpClient.PutAsync<ClientResponse>(
            endpoint,
            request,
            cancellationToken);

        _logger.LogInformation(
            "Client updated successfully: {ClientId} - {Rfc}",
            request.Id,
            request.Rfc);

        return response;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        if(string.IsNullOrWhiteSpace(clientId))
        {
            throw new ArgumentException("Client ID cannot be null or whitespace.", nameof(clientId));
        }

        _logger.LogDebug(
            "Deleting client with ID: {ClientId}",
            clientId);


        var endpoint = $"{BaseEndpoint}/{clientId}";
        await _httpClient.DeleteAsync(endpoint, cancellationToken);

        _logger.LogInformation(
            "Client deleted successfully: {ClientId}",
            clientId);
    }



    #region Validation

    /// <summary>
    /// Valida los parámetros de paginación.
    /// </summary>
    private static void ValidatePaginationParameters(int start, int length)
    {
        if (start < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(start),
                start,
                "El parámetro 'start' debe ser mayor o igual a 0.");
        }

        if (length < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(length),
                length,
                "El parámetro 'length' debe ser mayor a 0.");
        }

        if (length > MaxPageLength)
        {
            throw new ArgumentOutOfRangeException(
                nameof(length),
                length,
                $"El parámetro 'length' no puede ser mayor a {MaxPageLength}.");
        }
    }

    /// <summary>
    /// Valida la solicitud de creación de cliente.
    /// </summary>
    private static void ValidateCreateRequest(ClientRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Rfc))
        {
            throw new FacturamaValidationException("El RFC es requerido.");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            throw new FacturamaValidationException("El nombre es requerido.");
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new FacturamaValidationException("El email es requerido.");
        }

        if (string.IsNullOrWhiteSpace(request.FiscalRegime))
        {
            throw new FacturamaValidationException("El régimen fiscal es requerido.");
        }

        if (string.IsNullOrWhiteSpace(request.TaxZipCode))
        {
            throw new FacturamaValidationException("El código postal fiscal es requerido.");
        }

        if (string.IsNullOrWhiteSpace(request.CfdiUse))
        {
            throw new FacturamaValidationException("El uso de CFDI es requerido.");
        }
    }

    /// <summary>
    /// Valida la solicitud de actualización de cliente.
    /// </summary>
    private static void ValidateUpdateRequest(ClientRequest request)
    {
        // Para actualización, solo validamos si los campos están presentes
        if (request.Rfc != null && string.IsNullOrWhiteSpace(request.Rfc))
        {
            throw new FacturamaValidationException("El RFC no puede estar vacío.");
        }

        if (request.Name != null && string.IsNullOrWhiteSpace(request.Name))
        {
            throw new FacturamaValidationException("El nombre no puede estar vacío.");
        }

        if (request.Email != null && string.IsNullOrWhiteSpace(request.Email))
        {
            throw new FacturamaValidationException("El email no puede estar vacío.");
        }
    }

    #endregion

    
}
