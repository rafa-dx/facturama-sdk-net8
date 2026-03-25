using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Responses;


namespace Facturama.Sdk.Core.Abstractions
{
    public interface IRetentionService
    {
        // Create - crear retencion
        Task<RetentionResponse> CreateAsync(
            RetentionRequest request,
            CancellationToken cancellationToken = default);

        Task<RetentionResponse> GetAsync(
            string cfdiId,
            CancellationToken ctancellationToken = default);

        Task<IReadOnlyList<ListCfdiResponse>> ListAsync(
            RetentionFilter? filter = null,
            CancellationToken cancellationToken = default);

        Task<CfdiDownloadResponse> DownloadFileAsync(
            string cfdiId,
            string type,
            CancellationToken cancellationToken = default);

        Task<CfdiCancellationResponse> CancelAsync(
            string cfdiId,
            string? motive = null,
            string? uuidReplacement = null,
            CancellationToken cancellationToken = default);

        Task<CfdiSendResponse> SendByEmailAsync(
            string cfdiId,
            string email,
            CancellationToken cancellationToken = default);

    }
}
