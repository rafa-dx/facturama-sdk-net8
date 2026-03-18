using Facturama.Sdk.Core.Enums;
using Facturama.Sdk.Core.Models.Responses.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Abstractions
{
    public interface ICatalogService
    {
        #region Catálogos de Códigos Postales

        /// <summary>
        /// Busca información de un código postal específico.
        /// </summary>
        /// <param name="keydword">Código postal a buscar (5 dígitos).</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Información del código postal.</returns>
        Task<IReadOnlyList<PostalCodesCatalog>> GetPostalCodeAsync(
            string keydword,
            CancellationToken cancellationToken = default);
        #endregion

        /// <summary>
        /// Busca información de los tipos de relación disponibles para CFDI.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<RelationType>> GetRelationTypesAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Busca información de los países disponibles para CFDI.
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<IReadOnlyList<CountriesCatalog>> GetCountriesAsync(
            CancellationToken cancellation = default);

        /// <summary>
        /// Busca información de los estados disponibles para CFDI, filtrando por nombre de estado
        /// </summary>
        /// <param name="keydword"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<IReadOnlyList<State>> GetStatesAsync(
            string keydword,
            CancellationToken cancellation = default);

        /// <summary>
        /// Busca información de los municipios disponibles para CFDI, filtrando por nombre de estado
        /// </summary>
        /// <param name="keydword"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<IReadOnlyList<MunicipalitiesCatalogs>>  GetMunicipalitiesAsync(
            string keydword,
            CancellationToken cancellation = default);


        /// <summary>
        /// Buscar las localidades disponibles para CFDI, filtrando por nombre de estado y municipio
        /// </summary>
        /// <param name="keydword"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        Task<IReadOnlyList<LocalitiesCatalogs>> GetLocalitiesAsync(
            string keydword,
            CancellationToken cancellation = default);

        Task<IReadOnlyList<Neighborhood>> GetNeighborhoodsAsync(
            string keydword,
            CancellationToken cancellation = default);

        Task<IReadOnlyList<CfdiUse>> GetCfdiUsesAsync(
            CancellationToken cancellation = default);

        Task<IReadOnlyList<Unit>> GetUnitsAsync(
            string keydword,
            CancellationToken cancellation = default);

        Task<IReadOnlyList<ProductServicesCatalogs>> GetProductsServicesAsync(
            string keydword,
            CancellationToken cancellation = default);

        Task<IReadOnlyList<NameIdsCatalogs>> GetNameIdsAsync(
            CancellationToken cancellation = default);

        Task<IReadOnlyList<Currency>> GetCurrenciesAsync(
            string keydword,
            CancellationToken cancellation = default);

        Task<IReadOnlyList<Bank>> GetBanksAsync(
            CancellationToken cancellation = default);


        Task<IReadOnlyList<PaymentForm>> GetPaymentFormsAsync(
            CancellationToken cancellation = default);

       // PaymentMethods
       Task <IReadOnlyList<PaymentMethodsCatalogs>> GetPaymentMethodsAsync(
            CancellationToken cancellation = default);

        //CfdiTypes
        Task<IReadOnlyList<Models.Responses.Catalogs.CfdiType>> GetCfdiTypesAsync(
            CancellationToken cancellation = default);

        //FiscalRegimens
        Task <IReadOnlyList<FiscalRegimensCatalogs>> GetFiscalRegimensAsync(
            string keydword,
            CancellationToken cancellation = default);
    }
}
