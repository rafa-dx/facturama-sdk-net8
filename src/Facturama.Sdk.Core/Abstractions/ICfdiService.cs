using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;


namespace Facturama.Sdk.Core.Abstractions
{
    public interface ICfdiService
    {
        // CREATE - Crear factura
        Task<CfdiResponse> CreateAsync(
            CfdiRequest request,
            CancellationToken cancellationToken = default);

        // READ
        Task<CfdiResponse> GetAsync(
            string cfdiId,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<CfdiResponse>> ListAsync(
            int start = 0,
            int length = 50,
            string? search = null,
            CancellationToken cancellationToken = default);

        // Operaciones especiales de CFDI
        Task<byte[]> DownloadPdfAsync(
            string cfdiId,
            CancellationToken cancellationToken = default);

        Task<byte[]> DownloadXmlAsync(
            string cfdiId,
            CancellationToken cancellationToken = default);

        Task<CfdiResponse> CancelAsync(
            string cfdiId,
            string cancellationReason,
            CancellationToken cancellationToken = default);

        Task<string> SendByEmailAsync(
            string cfdiId,
            string email,
            CancellationToken cancellationToken = default);
    }
}
