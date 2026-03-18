using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;


namespace Facturama.Sdk.Core.Abstractions
{
    /// <summary>
    /// Servicio CFDI completo (API Web estándar).
    /// Incluye todas las operaciones disponibles.
    /// </summary>
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
        
        Task<IReadOnlyList<ListCfdiResponse>> ListAsync(
            CfdiFilter? filter = null,
            CancellationToken cancellationToken = default);

        Task <CfdiStatusResponse> GetStatusAsync(
            CfdiStatusParams filter,
            CancellationToken cancellationToken = default);

        Task<CfdiDownloadResponse> DownloadFileAsync(
            string FileType,
            string CfdiType,
            string CfdiId,
            CancellationToken cancellationToken = default);

        Task<CfdiCancellationResponse> CancelAsync(
          string cfdiId,
          string CfdiType,
          string? cancellationReason = null,
          string? uuidReplacement = null,
          CancellationToken cancellationToken = default);

        /// <summary>
        /// Envía CFDI por email (API Web - single emisor).
        /// </summary>
        Task<CfdiSendResponse> SendByEmailAsync(
            string cfdiId,
            string email,
            string cfdiType = "issued",
            CancellationToken cancellationToken = default);

       

    }
}
