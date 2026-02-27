using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services;

internal sealed class ProductService : IProductService
{
    private const string BaseEndpoint = "/api/Product";
    private const string BaseEndpointPaginated = "/api/Products";
    private const int MaxPageLength = 100;


    private readonly IFacturamaHttpClient _httpClient;
    private readonly ILogger<ProductService> _logger;

    /// <summary
    /// Inicia una nueva instancia de <see cref="ProductService"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
    /// <param name="logger">Logger para registrar información y errores.</param>

    public ProductService(
            IFacturamaHttpClient httpClient,
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
            //ValidateCreateRequest(request);

            _logger.LogInformation(
                "Creating product with name: {ProductName}",
                request.Name);

            try
            {
                var response = await _httpClient.PostAsync<ProductResponse>(
                    BaseEndpoint,
                    request,
                    cancellationToken);

                _logger.LogInformation(
                    "Product created successfully with name: {ProductName}",
                    response.Name);

                return response;
            }
            catch (FacturamaValidationException ex)
            {
                _logger.LogWarning(
                    "Validation failed while creating product with name: {ProductName}",
                    request.Name);
                throw;
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

    /// <inheritdoc/>
    public async Task<ProductResponse> GetAsync(
            string productId,
            CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(productId);

            _logger.LogInformation(
                "Retrieving product with ID: {ProductId}",
                productId);

            try
            {
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
            catch (FacturamaNotFoundException ex)
            {
                _logger.LogWarning(
                    "Product not found with ID: {ProductId}",
                    productId);
                throw;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while retrieving product with ID: {ProductId}",
                    productId);
                throw;
            }

        }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<ProductResponse>> ListAsync(
            CancellationToken cancellation = default)
        {
            _logger.LogInformation("Listing products");

            try
            {
                var response = await _httpClient.GetAsync<IReadOnlyList<ProductResponse>>(
                    BaseEndpoint,
                    queryParams: null,
                    cancellation);

                _logger.LogInformation(
                    "Products listed successfully. Total products: {ProductCount}",
                    response.Count);

                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while listing products");
                throw;
            }
        }

    /// <inheritdoc/>

    public async Task<PaginatedResponse<ProductResponse>> ListPaginatedAsync(
        int start = 0,
        int length = 50,
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
                var response = await _httpClient.GetAsync<PaginatedResponse<ProductResponse>>(
                    BaseEndpointPaginated,
                    queryParams,
                    cancellation);

                _logger.LogDebug("Retrieved {Count} of {Total} products",
                                 response.FilteredRecords,
                                 response.TotalRecords);
                return response;
            }
            catch (FacturamaException ex)
            {
                _logger.LogError(
                    ex,
                    "Error occurred while retrieving paginated products with start={Start}, length={Length}, search={Search}",
                    start,
                    length,
                    search ?? "(none)");
                throw;

            }
        }


    public async Task<ProductResponse> UpdateAsync(
        string productId,
        ProductRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productId);
        ArgumentNullException.ThrowIfNull(request);

        _logger.LogInformation(
            "Updating product with ID: {ProductId}",
            productId);

        try
        {
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

        catch (FacturamaNotFoundException ex)
        {
            _logger.LogWarning(
                "Product not found for update with ID: {ProductId}",
                productId);
            throw;
        }
        catch (FacturamaValidationException ex)
        {
            _logger.LogWarning(
                "Validation failed while updating product with ID: {ProductId}",
                productId);
            throw;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while updating product with ID: {ProductId}",
                productId);
            throw;
        }

    }

    public async Task DeleteAsync(
        string productId,
        CancellationToken cancelToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productId);

        _logger.LogInformation(
            "Deleting product with ID: {ProductId}",
            productId);

        try
        {
            var endpoint = $"{BaseEndpoint}/{productId}";
            await _httpClient.DeleteAsync(
                endpoint,
                cancelToken);
            _logger.LogInformation(
                "Product deleted successfully with ID: {ProductId}",
                productId);

        }
        catch (FacturamaNotFoundException ex)
        {
            _logger.LogWarning(
                "Product not found for deletion with ID: {ProductId}",
                productId);
            throw;
        }
        catch (FacturamaException ex)
        {
            _logger.LogError(
                ex,
                "Error occurred while deleting product with ID: {ProductId}",
                productId);
            throw;
        }
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

