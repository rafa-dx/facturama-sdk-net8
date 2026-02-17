namespace Facturama.Sdk.Core.Abstractions
{
    public interface IFacturamaHttpClient
    {
        Task<TResponse> GetAsync<TResponse>(
            string endpoint, 
            Dictionary<string, string?>? queryParams = null,
            CancellationToken cancellationToken = default);


        Task<TResponse> PostAsync<TResponse>(
             string endpoint,
             object request,
             CancellationToken cancellationToken = default);

        Task<TResponse> PutAsync<TResponse>(
            string endpoint,
            object request,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            string endpoint,
            CancellationToken cancellationToken = default);
    }