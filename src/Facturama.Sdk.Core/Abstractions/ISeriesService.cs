using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Responses;


namespace Facturama.Sdk.Core.Abstractions
{
    public interface ISeriesService
    {
        Task<IReadOnlyList<SerieResponse>> ListSerieAsync(
            string Id,
            CancellationToken cancellation= default);

        Task<SerieResponse> CreateSerieAsync(
            string Id,
            SerieRequest request,
            CancellationToken cancellation = default);

        Task<SerieResponse> DeleteSerieAsync(
            string Id, CancellationToken cancellation = default);

        
    }
}
