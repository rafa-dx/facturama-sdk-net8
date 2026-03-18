using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Responses;

namespace Facturama.Sdk.Core.Abstractions
{
    public interface ITaxEntityService
    {
        Task<TaxEntityCsdResponse> PutCsdAsync(
            TaxEntityCsdRequest request,
            CancellationToken cancellationToken = default);

        Task<TaxEntityCsdResponse> PutCsdFielAsync(
            TaxEntityCsdRequest request,
            CancellationToken cancellationToken = default);

        Task<TaxEntityResponse> GetTaxEntityAsync(
            CancellationToken cancellationToken = default);

        Task<TaxEntityResponse>PutTaxEntityAsync(
            TaxEntityRequest request,
            CancellationToken cancellationToken = default);

        Task<TaxEntityLogoResponse>PutTaxEntityLogoAsync(
            TaxEntityLogoRequest request,
            CancellationToken cancellation = default);
    }
}
