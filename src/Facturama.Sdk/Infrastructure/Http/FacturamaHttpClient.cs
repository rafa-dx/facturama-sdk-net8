// src/Facturama.Sdk/Infrastructure/Http/FacturamaHttpClient.cs

using FacturamaAPI.src.Facturama.Sdk.Core.Abstractions;
using FacturamaAPI.src.Facturama.Sdk.Core.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Facturama.Sdk.Infrastructure.Http;

/// <summary>
/// Implementación del cliente HTTP para comunicarse con la API de Facturama.
/// </summary>
internal sealed class FacturamaHttpClient : IFacturamaHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<FacturamaHttpClient> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="FacturamaHttpClient"/>.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP configurado con BaseAddress, Timeout y Authentication.</param>
    /// <param name="logger">Logger para diagnósticos.</param>
    public FacturamaHttpClient(
        HttpClient httpClient,
        ILogger<FacturamaHttpClient> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }

    /// <inheritdoc/>
    public async Task<TResponse> GetAsync<TResponse>(
        string endpoint,
        Dictionary<string, string?>? queryParams = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpoint);

        var url = BuildUrl(endpoint, queryParams);
        var stopwatch = Stopwatch.StartNew();

        try
        {
            _logger.LogDebug("GET request to {Url}", url);

            var response = await _httpClient.GetAsync(url, cancellationToken)
                .ConfigureAwait(false);

            var result = await HandleResponseAsync<TResponse>(response, cancellationToken)
                .ConfigureAwait(false);

            _logger.LogDebug(
                "GET {Url} completed in {ElapsedMs}ms with status {StatusCode}",
                url,
                stopwatch.ElapsedMilliseconds,
                response.StatusCode);

            return result;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error during GET to {Endpoint}", endpoint);
            throw new FacturamaConnectionException(
                "Failed to connect to Facturama API. Check your network connection.", ex);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogError(ex, "Timeout during GET to {Endpoint}", endpoint);
            throw new FacturamaTimeoutException(
                (int)_httpClient.Timeout.TotalSeconds, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<TResponse> PostAsync<TResponse>(
        string endpoint,
        object request,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpoint);
        ArgumentNullException.ThrowIfNull(request);

        var stopwatch = Stopwatch.StartNew();

        try
        {
            _logger.LogDebug("POST request to {Endpoint}", endpoint);

            var json = JsonSerializer.Serialize(request, _jsonOptions);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content, cancellationToken)
                .ConfigureAwait(false);

            var result = await HandleResponseAsync<TResponse>(response, cancellationToken)
                .ConfigureAwait(false);

            _logger.LogDebug(
                "POST {Endpoint} completed in {ElapsedMs}ms with status {StatusCode}",
                endpoint,
                stopwatch.ElapsedMilliseconds,
                response.StatusCode);

            return result;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error during POST to {Endpoint}", endpoint);
            throw new FacturamaConnectionException(
                "Failed to connect to Facturama API. Check your network connection.", ex);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogError(ex, "Timeout during POST to {Endpoint}", endpoint);
            throw new FacturamaTimeoutException(
                (int)_httpClient.Timeout.TotalSeconds, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<TResponse> PutAsync<TResponse>(
        string endpoint,
        object request,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpoint);
        ArgumentNullException.ThrowIfNull(request);

        var stopwatch = Stopwatch.StartNew();

        try
        {
            _logger.LogDebug("PUT request to {Endpoint}", endpoint);

            var json = JsonSerializer.Serialize(request, _jsonOptions);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content, cancellationToken)
                .ConfigureAwait(false);

            var result = await HandleResponseAsync<TResponse>(response, cancellationToken)
                .ConfigureAwait(false);

            _logger.LogDebug(
                "PUT {Endpoint} completed in {ElapsedMs}ms with status {StatusCode}",
                endpoint,
                stopwatch.ElapsedMilliseconds,
                response.StatusCode);

            return result;
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error during PUT to {Endpoint}", endpoint);
            throw new FacturamaConnectionException(
                "Failed to connect to Facturama API. Check your network connection.", ex);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogError(ex, "Timeout during PUT to {Endpoint}", endpoint);
            throw new FacturamaTimeoutException(
                (int)_httpClient.Timeout.TotalSeconds, ex);
        }
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(
        string endpoint,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpoint);

        var stopwatch = Stopwatch.StartNew();

        try
        {
            _logger.LogDebug("DELETE request to {Endpoint}", endpoint);

            var response = await _httpClient.DeleteAsync(endpoint, cancellationToken)
                .ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                await ThrowFacturamaExceptionAsync(response, cancellationToken)
                    .ConfigureAwait(false);
            }

            _logger.LogDebug(
                "DELETE {Endpoint} completed in {ElapsedMs}ms with status {StatusCode}",
                endpoint,
                stopwatch.ElapsedMilliseconds,
                response.StatusCode);
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error during DELETE to {Endpoint}", endpoint);
            throw new FacturamaConnectionException(
                "Failed to connect to Facturama API. Check your network connection.", ex);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogError(ex, "Timeout during DELETE to {Endpoint}", endpoint);
            throw new FacturamaTimeoutException(
                (int)_httpClient.Timeout.TotalSeconds, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<byte[]> GetBytesAsync(
        string endpoint,
        Dictionary<string, string>? queryParams = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpoint);

        var url = BuildUrl(endpoint, queryParams);
        var stopwatch = Stopwatch.StartNew();

        try
        {
            _logger.LogDebug("GET (bytes) request to {Url}", url);

            var response = await _httpClient.GetAsync(url, cancellationToken)
                .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var bytes = await response.Content.ReadAsByteArrayAsync(cancellationToken)
                    .ConfigureAwait(false);

                _logger.LogDebug(
                    "GET (bytes) {Url} completed in {ElapsedMs}ms, received {ByteCount} bytes",
                    url,
                    stopwatch.ElapsedMilliseconds,
                    bytes.Length);

                return bytes;
            }

            await ThrowFacturamaExceptionAsync(response, cancellationToken)
                .ConfigureAwait(false);

            return Array.Empty<byte>(); // Nunca llega aquí
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error during GET (bytes) to {Endpoint}", endpoint);
            throw new FacturamaConnectionException(
                "Failed to connect to Facturama API. Check your network connection.", ex);
        }
        catch (TaskCanceledException ex) when (!cancellationToken.IsCancellationRequested)
        {
            _logger.LogError(ex, "Timeout during GET (bytes) to {Endpoint}", endpoint);
            throw new FacturamaTimeoutException(
                (int)_httpClient.Timeout.TotalSeconds, ex);
        }
    }

    /// <summary>
    /// Construye la URL completa con query parameters.
    /// </summary>
    private static string BuildUrl(string endpoint, Dictionary<string, string>? queryParams)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(endpoint);

        if (queryParams == null || queryParams.Count == 0)
            return endpoint;

        var queryString = string.Join("&",
            queryParams
                .Where(kvp => !string.IsNullOrWhiteSpace(kvp.Value))
                .Select(kvp => $"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}"));

        if (string.IsNullOrEmpty(queryString))
            return endpoint;
        endpoint = endpoint.TrimEnd('?', '&');

        var separator = endpoint.Contains('?') ? '&' : '?';
        return $"{endpoint}{separator}{queryString}";
    }

    /// <summary>
    /// Maneja la respuesta HTTP: deserializa si es exitosa o lanza excepción si falló.
    /// </summary>
    private async Task<T> HandleResponseAsync<T>(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
        {
            // Manejar 204 No Content
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                _logger.LogDebug("Received 204 No Content, returning default value");
                return default!;
            }

            var json = await response.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(json))
            {
                _logger.LogWarning("Response content is empty for successful request");
                throw new FacturamaException(
                    "The server returned a successful status but the response content is empty.");
            }

            try
            {
                return JsonSerializer.Deserialize<T>(json, _jsonOptions)
                    ?? throw new FacturamaException(
                        "Failed to deserialize response. The response was null.");
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize JSON response: {Json}", json);
                throw new FacturamaException(
                    "Failed to deserialize the API response. The response format may be invalid.", ex);
            }
        }

        await ThrowFacturamaExceptionAsync(response, cancellationToken)
            .ConfigureAwait(false);

        return default!; // Nunca llega aquí
    }

    /// <summary>
    /// Mapea el código de estado HTTP a la excepción tipada correspondiente y la lanza.
    /// </summary>
    private async Task ThrowFacturamaExceptionAsync(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken)
            .ConfigureAwait(false);

        var exception = response.StatusCode switch
        {
            HttpStatusCode.Unauthorized =>
                new FacturamaAuthenticationException(
                    "Authentication failed. Check your username and password.", content),

            HttpStatusCode.BadRequest =>
                new FacturamaValidationException(
                    "The request data is invalid. Check the error details.", content),

            HttpStatusCode.NotFound =>
                new FacturamaNotFoundException(
                    "The requested resource was not found.", content),

            HttpStatusCode.TooManyRequests =>
                new FacturamaRateLimitException(
                    "Rate limit exceeded. Please wait before making more requests.", content),

            HttpStatusCode.InternalServerError =>
                new FacturamaServerException(
                    "Internal server error occurred at Facturama.", content, HttpStatusCode.InternalServerError),

            _ when (int)response.StatusCode >= 500 =>
                new FacturamaServerException(
                    $"Server error occurred (HTTP {(int)response.StatusCode}).", content, response.StatusCode),

            _ =>
                new FacturamaException(
                    $"Request failed with status code {(int)response.StatusCode} ({response.StatusCode}).",
                    content,
                    response.StatusCode)
        };

        _logger.LogError(
            exception,
            "Request failed with status {StatusCode}. Response: {ResponseContent}",
            response.StatusCode,
            content);

        throw exception;
    }
}
