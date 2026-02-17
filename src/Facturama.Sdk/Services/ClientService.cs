// src/Facturama.Sdk/Services/ClientService.cs
using FacturamaAPI.src.Facturama.Sdk.Core.Abstractions;
using FacturamaAPI.src.Facturama.Sdk.Core.Exceptions;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Request; 
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Common;
using FacturamaAPI.src.Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;
namespace FacturamaAPI.src.Facturama.Sdk.Services;

/// <summary>
/// Implementación del servicio de gestión de clientes de Facturama.
/// </summary>
internal sealed class ClientService : IClientService
{
    private const string BaseEndpoint = "/api/client";
    private const string BaseEndpointPaginated = "/api/Clients?";
    private const int MaxPageLength = 100;

    private readonly IFacturamaHttpClient _httpClient;
    private readonly ILogger<ClientService> _logger;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="ClientService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP de Facturama.</param>
    /// <param name="logger">Logger para diagnósticos.</param>
    public ClientService(
        IFacturamaHttpClient httpClient,
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

        _logger.LogInformation(
            "Creating client with RFC: {Rfc}",
            request.Rfc);

        try
        {
            var response = await _httpClient.PostAsync<ClientResponse>(
                BaseEndpoint,
                request,
                cancellationToken);

            _logger.LogInformation(
                "Client created successfully with ID: {ClientId}, RFC: {Rfc}",
                response.Id,
                response.Rfc);

            return response;
        }
        catch (FacturamaValidationException ex)
        {
            _logger.LogWarning(
                ex,
                "Validation failed when creating client with RFC: {Rfc}",
                request.Rfc);
            throw;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Failed to create client with RFC: {Rfc}",
                request.Rfc);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<ClientResponse> GetAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(clientId);

        _logger.LogDebug("Retrieving client with ID: {ClientId}", clientId);

        try
        {
            var endpoint = $"{BaseEndpoint}/{clientId}";
            var response = await _httpClient.GetAsync<ClientResponse>(
                endpoint,
                queryParams: null,
                cancellationToken);

            _logger.LogDebug(
                "Client retrieved successfully: {ClientId} - {Rfc}",
                response.Id,
                response.Rfc);

            return response;
        }
        catch (FacturamaNotFoundException ex)
        {
            _logger.LogWarning(
                ex,
                "Client not found with ID: {ClientId}",
                clientId);
            throw;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Failed to retrieve client with ID: {ClientId}",
                clientId);
            throw;
        }
    }

    
    /// <inheritdoc/>
    public async Task<IReadOnlyList<ClientResponse>> ListAsync(
        string? Rfc = null,
    CancellationToken cancellationToken = default)
    {
        
        _logger.LogDebug("Retrieving all clients (no pagination)");

        try
        {
            var queryParams = string.IsNullOrEmpty(Rfc) ? null :
                new Dictionary<string, string?>
            {
                ["keyword"] = Rfc
            };
            var response = await _httpClient.GetAsync<List<ClientResponse>>(
                BaseEndpoint,
                queryParams,
                cancellationToken);

            _logger.LogDebug(
                "Retrieved {Count} clients",
                response.Count);

            return response.AsReadOnly();
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(ex, "Failed to retrieve clients list");
            throw;
        }
    }
    /// <inheritdoc/>
    public async Task<PaginatedResponse<ClientResponse>> ListPaginatedAsync(
        int start = 0,
        int length = 50,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        ValidatePaginationParameters(start, length);

        _logger.LogDebug(
            "Retrieving clients with pagination: start={Start}, length={Length}, search={Search}",
            start,
            length,
            search ?? "(none)");

        try
        {
            var queryParams = new Dictionary<string, string>
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

            _logger.LogDebug(
                "Retrieved {Count} of {Total} clients",
                response.FilteredRecords,
                response.TotalRecords);

            return response;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Failed to retrieve paginated clients list (start={Start}, length={Length})",
                start,
                length);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task<ClientResponse> UpdateAsync(
        string clientId,
        ClientRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(clientId);
        ArgumentNullException.ThrowIfNull(request);
        ValidateUpdateRequest(request);

        _logger.LogInformation(
            "Updating client with ID: {ClientId}",
            clientId);

        try
        {
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
        catch (FacturamaNotFoundException ex)
        {
            _logger.LogWarning(
                ex,
                "Client not found for update with ID: {ClientId}",
                clientId);
            throw;
        }
        catch (FacturamaValidationException ex)
        {
            _logger.LogWarning(
                ex,
                "Validation failed when updating client with ID: {ClientId}",
                clientId);
            throw;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Failed to update client with ID: {ClientId}",
                clientId);
            throw;
        }
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        string clientId,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(clientId);

        _logger.LogInformation(
            "Deleting client with ID: {ClientId}",
            clientId);

        try
        {
            var endpoint = $"{BaseEndpoint}/{clientId}";
            await _httpClient.DeleteAsync(endpoint, cancellationToken);

            _logger.LogInformation(
                "Client deleted successfully: {ClientId}",
                clientId);
        }
        catch (FacturamaNotFoundException ex)
        {
            _logger.LogWarning(
                ex,
                "Client not found for deletion with ID: {ClientId}",
                clientId);
            throw;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Failed to delete client with ID: {ClientId}",
                clientId);
            throw;
        }
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

// Notas de implementación:
//
// 1. Endpoints de Facturama:
//    - POST   /api/clients           → CreateAsync
//    - GET    /api/clients/{id}      → GetAsync
//    - GET    /api/clients           → ListAsync (sin paginación)
//    - GET    /api/clients?start&... → ListAsync (con paginación)
//    - PUT    /api/clients/{id}      → UpdateAsync
//    - DELETE /api/clients/{id}      → DeleteAsync
//
// 2. Validación:
//    - Validación básica en el servicio (campos requeridos, rangos)
//    - Para validación más compleja, considera integrar FluentValidation
//    - La API también valida, por lo que algunas validaciones son redundantes
//      pero mejoran la experiencia del desarrollador
//
// 3. Logging:
//    - LogInformation para operaciones de escritura (Create, Update, Delete)
//    - LogDebug para operaciones de lectura (Get, List)
//    - LogWarning para casos esperados (NotFound, Validation)
//    - LogError para fallos inesperados
//
// 4. GetByRfcAsync:
//    - Implementado usando búsqueda con paginación + filtro en memoria
//    - Si Facturama agrega endpoint específico, refactorizar a llamada directa
//    - Búsqueda case-insensitive para mayor flexibilidad
//
// 5. Paginación:
//    - start: índice base 0
//    - length: máximo 100 por página (configurable en constante)
//    - search: búsqueda en RFC, nombre, email (implementado por API)
//
// 6. Thread-safety:
//    - Servicio es stateless (sin campos mutables)
//    - Puede registrarse como Scoped o Singleton en DI
//    - Todas las operaciones son async
//
// 7. Testing:
//    - Mockear IFacturamaHttpClient para tests unitarios
//    - Verificar logging con mock de ILogger
//    - Tests de integración contra Sandbox de Facturama