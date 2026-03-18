using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Abstractions
{
    /// <summary>
    /// Servicio CFDI para API Multiemisor.
    /// Incluye capacidades específicas de multiemisor.
    /// </summary>
    public interface ICfdiLiteService
    {
        // CREATE 
        Task<CfdiResponse> CreateAsync(
            CfdiLiteRequest request,
            int? version = null,
            CancellationToken cancellationToken = default);

        // READ
        Task<CfdiResponse> GetAsync(
            string cfdiId, 
            CancellationToken ct = default);
        Task<IReadOnlyList<ListCfdiResponse>> ListAsync(
            CfdiFilter? filter = null, 
            CancellationToken cancellationToken = default);

        // STATUS
        Task<CfdiStatusResponse> GetStatusAsync(
            CfdiStatusParams filter, 
            CancellationToken cancellationToken = default);

        // DOWNLOAD
        Task<CfdiDownloadResponse> DownloadFileAsync(
            string fileType, 
            string cfdiType, 
            string cfdiId, 
            CancellationToken cancellationToken = default);

        // CANCEL
        Task<CfdiCancellationResponse> CancelAsync(
            string cfdiId, 
            string cfdiType, 
            string? motive = null, 
            string? uuidReplacement = null, 
            CancellationToken cancellationToken = default);

        // SEND (Multiemisor - requiere issuerEmail)
        Task<CfdiSendResponse> SendByEmailAsync(
            string cfdiId,
            string email,
            string issuerEmail,
            string? subject = null,
            string? comments = null,
            string cfdiType = "issuedLite",
            CancellationToken ct = default);

        Task<CsdResponse> UploadCsdAsync(
            CsdRequest request, 
            CancellationToken cancellationToken = default);

        Task<CsdResponse> GetCsdAsync(
            string rfc, 
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<CsdResponse>> ListCsdAsync(
           CancellationToken cancellationToken = default);

        Task <CsdResponse> DeleteCsdAsync(
            string rfc, 
            CancellationToken cancellationToken = default);

        Task <CsdResponse> UpdateCsdAsync(
            string rfc,
            CsdRequest request, 
            CancellationToken cancellationToken = default);
    }
}
