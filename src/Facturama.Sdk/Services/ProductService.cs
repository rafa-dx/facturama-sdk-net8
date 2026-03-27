using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services;

/// <summary>
/// Implementacion del servicio de gestion de productos de facturama
/// </summary>
public sealed class ProductService : IProductService
{
    private const string BaseEndpoint = "Product";
    private const string BaseEndpointPaginated = "Products";
    private const int MaxPageLength = 100;


    private readonly IApiWebHttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;

    /// <summary
    /// Inicia una nueva instancia de <see cref="ProductService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
    /// <param name="logger">Logger para registrar información y errores.</param>

    public ProductService(
            IApiWebHttpClient httpClient,
            ILogger<ProductService> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public async Task<ProductResponse> CreateAsync(
            ProductRequest request,
            CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        _logger.LogDebug(
            "Creating product with name: {ProductName}",
            request.Name);


        var response = await _httpClient.PostAsync<ProductResponse>(
            BaseEndpoint,
            request,
            null,
            cancellationToken);

        _logger.LogInformation(
            "Product created successfully with name: {ProductName}",
            response.Name);

        return response;

    }

    /// <inheritdoc/>
    public async Task<ProductResponse> GetAsync(
            string productId,
            CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productId);

        _logger.LogDebug(
            "Retrieving product with ID: {ProductId}",
            productId);

        var endpoint = $"{BaseEndpoint}/{productId}";
        var response = await _httpClient.GetAsync<ProductResponse>(
            endpoint,
            queryParams: null,
            cancellationToken);

        _logger.LogInformation(
            "Product retrieved successfully with ID: {ProductId}",
            productId);

        return response;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<ProductResponse>> ListAsync(
        string? keyword = null,
        CancellationToken cancellation = default)
    {
        _logger.LogDebug("Listing products");

        var queryParams = string.IsNullOrEmpty(keyword) ? null :
            new Dictionary<string, string?>
            {
                ["keyword"] = keyword
            };


        var response = await _httpClient.GetAsync<IReadOnlyList<ProductResponse>>(
            BaseEndpoint,
            queryParams,
            cancellation);

        _logger.LogInformation(
            "Products listed successfully. Total products: {ProductCount}",
            response.Count);

        return response;
    }



    /// <inheritdoc/>

    public async Task<PaginatedResponse<ProductResponse>> ListPaginatedAsync(
        int start = 0,
        int length = 100,
        string? search = null,
            CancellationToken cancellation = default)
    {
        ValidatePaginationParameters(
            start,
            length);
            
        _logger.LogDebug("Retrieving clients with pagination: start={Start}, length={Length}, search={Search}",
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

        var response = await _httpClient.GetAsync<PaginatedResponse<ProductResponse>>(
            BaseEndpointPaginated,
            queryParams,
            cancellation);

        _logger.LogInformation("Retrieved {Count} of {Total} products",
            response.recordsFiltered,
            response.recordsTotal);

        return response;

    }

    /// <inheritdoc/>
    public async Task<ProductResponse> UpdateAsync(
        string productId,
        ProductRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productId);
        ArgumentNullException.ThrowIfNull(request);

        _logger.LogDebug(
            "Updating product with ID: {ProductId}",
            productId);


        var endpoint = $"{BaseEndpoint}/{productId}";
        var response = await _httpClient.PutAsync<ProductResponse>(
            endpoint,
            request,
            cancellationToken);

        _logger.LogInformation(
            "Product updated successfully with ID: {ProductId}",
            productId);

        return response;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        string productId,
        CancellationToken cancelToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productId);

        _logger.LogDebug(
            "Deleting product with ID: {ProductId}",
            productId);


        var endpoint = $"{BaseEndpoint}/{productId}";
        await _httpClient.DeleteAsync(
            endpoint,
            cancelToken);

        _logger.LogInformation(
            "Product deleted successfully with ID: {ProductId}",
            productId);

    }

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
}

