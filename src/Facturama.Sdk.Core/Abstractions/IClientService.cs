using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;

namespace Facturama.Sdk.Core.Abstractions
{
    public interface IClientService
    {
        // CREATE
        Task<ClientResponse> CreateAsync(
        ClientRequest request,
        CancellationToken cancellationToken = default);

        // READ (individual)
        Task<ClientResponse> GetAsync(
            string clientId,
            CancellationToken cancellationToken = default);


        // READ (lista simple with Rfc)
        Task<IReadOnlyList<ClientResponse>> ListAsync(
            string? rfc = null,
            CancellationToken cancellationToken = default);

        // READ (lista con paginación)
        Task<PaginatedResponse<ClientResponse>> ListPaginatedAsync(
            int start = 0,
            int length = 50,
            string? search = null,
            CancellationToken cancellationToken = default);

        // UPDATE
        Task<ClientResponse> UpdateAsync(
            string clientId,
            ClientRequest request,
            CancellationToken cancellationToken = default);

        // DELETE
        Task DeleteAsync(
            string clientId,
            CancellationToken cancellationToken = default);
    }
}