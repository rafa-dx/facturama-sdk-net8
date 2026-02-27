using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;


namespace Facturama.Sdk.Core.Abstractions
{
    public interface IBranchOfficeService
    {
        //Create
        Task<BranchOfficeResponse> CreateAsync(
                BranchOfficeRequest request,
                CancellationToken cancellationToken = default);

        //List
        Task<IReadOnlyList<BranchOfficeResponse>> ListAsync(
            CancellationToken cancellationToken = default);

        //Get by id
        Task<BranchOfficeResponse> GetByIdAsync(
            string branchOfficeId,
            CancellationToken cancellationToken = default);

        //Update
        Task<BranchOfficeResponse> UpdateAsync(
            string branchOfficeId,
            BranchOfficeRequest request,
            CancellationToken cancellationToken = default);

        //Delete
        Task DeleteAsync(
            string branchOfficeId,
            CancellationToken cancellationToken = default);


    }
}
