using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Responses.Catalogs;
using Microsoft.Extensions.Logging;


namespace Facturama.Sdk.Services
{
    public sealed class CatalogService : ICatalogService
    {
        private string BaseEndpoint => "Catalogs";

        private readonly IApiWebHttpClient _httpClient;
        private readonly ILogger<CatalogService> _logger;

        ///<summary>
        ///Inicia una nueva instancia de <see cref="CatalogService"/>.
        ///</summary>
        ///<params name="httpClient">Cliente HTTP para realizar solicitudes a la API.</param>
        ///<params name="logger">Logger para registrar información y errores.</param>

        ///constructor
        public CatalogService(
            IApiWebHttpClient httpClient,
            ILogger<CatalogService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<IReadOnlyList<PostalCodesCatalog>> GetPostalCodeAsync(
            string keyword,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(keyword) || keyword.Length != 5)
            {
                throw new ArgumentException("El código postal debe ser una cadena de 5 dígitos.", nameof(keyword));
            }

            var queryParameters = new Dictionary<string, string?>
            {
                { "keyword", keyword }
            };

            _logger.LogDebug(
                "Fetching information for postal code: {keyword}",
                keyword);

            return _httpClient.GetAsync<IReadOnlyList<PostalCodesCatalog>>(
                $"{BaseEndpoint}/postalcodes",
                    queryParameters,
                    cancellationToken);
        }

        public Task<IReadOnlyList<RelationType>> GetRelationTypesAsync(
            CancellationToken cancellationToken = default)
        {
            _logger.LogDebug("Fetching relation types catalog...");

            return _httpClient.GetAsync<IReadOnlyList<RelationType>>(
                $"{BaseEndpoint}/relationtypes",
                null,
                cancellationToken);
        }

        public Task<IReadOnlyList<CountriesCatalog>> GetCountriesAsync(
            CancellationToken cancellation = default)
        {
            _logger.LogDebug("Fetching continent catalog...");

            return _httpClient.GetAsync<IReadOnlyList<CountriesCatalog>>(
                $"{BaseEndpoint}/countries",
                null,
                cancellation);

        }

        public Task<IReadOnlyList<State>> GetStatesAsync(
            string keyword,
            CancellationToken cancellation = default)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("El código del estado no puede estar vacío.", nameof(keyword));
            }
            var queryParameters = new Dictionary<string, string?>
            {
                { "countryCode", keyword }
            };
            _logger.LogDebug(
                "Fetching states catalog for code: {keyword}",
                keyword);

            return _httpClient.GetAsync<IReadOnlyList<State>>(
                $"{BaseEndpoint}/states",
                    queryParameters,
                    cancellation);
        }

        public Task<IReadOnlyList<MunicipalitiesCatalogs>> GetMunicipalitiesAsync(
            string keyword,
            CancellationToken cancellation = default)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("El código del estado no puede estar vacío.", nameof(keyword));
            }
            var queryParameters = new Dictionary<string, string?>
            {
                { "stateCode", keyword }
            };
            _logger.LogDebug(
                "Fetching municipalities catalog for code: {keyword}",
                keyword);

            return _httpClient.GetAsync<IReadOnlyList<MunicipalitiesCatalogs>>(
                $"{BaseEndpoint}/municipalities",
                    queryParameters,
                    cancellation);
        }

        public Task<IReadOnlyList<LocalitiesCatalogs>> GetLocalitiesAsync(
            string keyword,
            CancellationToken cancellation = default)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("El código del municipio no puede estar vacío.", nameof(keyword));
            }
            var queryParameters = new Dictionary<string, string?>
            {
                { "municipalityCode", keyword }
            };
            _logger.LogDebug(
                "Fetching localities catalog for code: {keyword}",
                keyword);

            return _httpClient.GetAsync<IReadOnlyList<LocalitiesCatalogs>>(
                $"{BaseEndpoint}/localities",
                    queryParameters,
                    cancellation);
        }

        public Task<IReadOnlyList<Neighborhood>> GetNeighborhoodsAsync(
            string keyword,
            CancellationToken cancellation = default)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                throw new ArgumentException("El código de la localidad no puede estar vacío.", nameof(keyword));
            }
            var queryParameters = new Dictionary<string, string?>
            {
                { "localityCode", keyword }
            };
            _logger.LogDebug(
                "Fetching neighborhoods catalog for code: {keyword}",
                keyword);

            return _httpClient.GetAsync<IReadOnlyList<Neighborhood>>(
                $"{BaseEndpoint}/neighborhoods",
                    queryParameters,
                    cancellation);
        }

        public Task<IReadOnlyList<CfdiUse>> GetCfdiUsesAsync(
            CancellationToken cancellation = default)
        {
            _logger.LogDebug("Fetching CFDI uses catalog...");

            return _httpClient.GetAsync<IReadOnlyList<CfdiUse>>(
                $"{BaseEndpoint}/cfdiuses",
                null,
                cancellation);
        }

        public Task<IReadOnlyList<Unit>> GetUnitsAsync(
            string? keyword = null,
            CancellationToken cancellation = default)
        {

            var queryParameters = new Dictionary<string, string?>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParameters["keyword"] = keyword;
            }
            ;
            _logger.LogInformation("Fetching units catalog. Filter: {Unit}", keyword ?? "none");
            return _httpClient.GetAsync<IReadOnlyList<Unit>>(
                $"{BaseEndpoint}/Units",
                queryParameters.Count > 0 ? queryParameters : null,
                cancellation);
        }

        public Task<IReadOnlyList<ProductServicesCatalogs>> GetProductsServicesAsync(
            string? keyword = null,
            CancellationToken cancellation = default)
        {
            var queryParameters = new Dictionary<string, string?>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParameters["keyword"] = keyword;
            }
            _logger.LogInformation("Fetching product/services catalog. Filter: {Keyword}", keyword ?? "none");
            return _httpClient.GetAsync<IReadOnlyList<ProductServicesCatalogs>>(
                $"{BaseEndpoint}/productsorservices",
                queryParameters.Count > 0 ? queryParameters : null,
                cancellation);
        }

        public Task<IReadOnlyList<NameIdsCatalogs>> GetNameIdsAsync(
            CancellationToken cancellation = default)
        {

            _logger.LogInformation("Fetching name/IDs catalog");
            return _httpClient.GetAsync<IReadOnlyList<NameIdsCatalogs>>(
                $"{BaseEndpoint}/nameids",
                null,
                cancellation);
        }

        public Task<IReadOnlyList<Currency>> GetCurrenciesAsync(
            string? keyword = null,
            CancellationToken cancellation = default)
        {
            var queryParameters = new Dictionary<string, string?>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParameters["keyword"] = keyword;
            }
            _logger.LogInformation("Fetching currencies catalog. Filter: {Keyword}", keyword ?? "none");
            return _httpClient.GetAsync<IReadOnlyList<Currency>>(
                $"{BaseEndpoint}/currencies",
                queryParameters.Count > 0 ? queryParameters : null,
                cancellation);
        }

        public Task<IReadOnlyList<Bank>> GetBanksAsync(
            CancellationToken cancellation = default)
        {

            _logger.LogInformation("Fetching banks catalog");
            return _httpClient.GetAsync<IReadOnlyList<Bank>>(
                $"{BaseEndpoint}/banks",
                null,
                cancellation);
        }

        public Task<IReadOnlyList<PaymentMethodsCatalogs>> GetPaymentMethodsAsync(
            CancellationToken cancellation = default)
        {
            _logger.LogInformation("Fetching payment methods catalog");
            return _httpClient.GetAsync<IReadOnlyList<PaymentMethodsCatalogs>>(
                $"{BaseEndpoint}/paymentmethods",
                null,
                cancellation);
        }

        public Task<IReadOnlyList<PaymentForm>> GetPaymentFormsAsync(
            CancellationToken cancellation = default)
        {

            _logger.LogInformation("Fetching payment forms catalog");
            return _httpClient.GetAsync<IReadOnlyList<PaymentForm>>(
                $"{BaseEndpoint}/paymentforms",
                null,
                cancellation);
        }

        public Task<IReadOnlyList<CfdiType>> GetCfdiTypesAsync(
            CancellationToken cancellation = default)
        {

            _logger.LogInformation("Fetching CFDI types catalog");
            return _httpClient.GetAsync<IReadOnlyList<CfdiType>>(
                $"{BaseEndpoint}/cfditypes",
                null,
                cancellation);
        }

        public Task<IReadOnlyList<FiscalRegimensCatalogs>> GetFiscalRegimensAsync(
            string? keyword = null,
            CancellationToken cancellation = default)
        {
            var queryParameters = new Dictionary<string, string?>();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                queryParameters["rfc"] = keyword;
            }
            _logger.LogInformation("Fetching fiscal regimens catalog. Filter: {rfc}", keyword ?? "none");
            return _httpClient.GetAsync<IReadOnlyList<FiscalRegimensCatalogs>>(
                $"{BaseEndpoint}/fiscalregimens",
                queryParameters.Count > 0 ? queryParameters : null,
                cancellation);
        }

    }
}
