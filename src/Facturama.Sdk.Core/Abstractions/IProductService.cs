using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;

namespace Facturama.Sdk.Core.Abstractions
{
    public interface IProductService
    {
        //CREATE
        Task<ProductResponse> CreateAsync(
            ProductRequest request,
            CancellationToken cancellationToken = default);

        //READF (individual)
        Task<ProductResponse> GetAsync(
            string productId,
            CancellationToken cancellationToken = default);

        // READ (lista)
        Task<IReadOnlyList<ProductResponse>> ListAsync(
            CancellationToken cancellationToken = default);

        // READ (lista con paginación)
        Task<PaginatedResponse<ProductResponse>> ListPaginatedAsync(
            int start = 0,
            int length = 50,
            string? search = null,
            CancellationToken cancellationToken = default);

        // UPDATE
        Task<ProductResponse> UpdateAsync(
            string productId,
            ProductRequest request,
            CancellationToken cancellationToken = default);

        // DELETE
        Task DeleteAsync(
            string productId,
            CancellationToken cancellationToken = default);
    }
}
