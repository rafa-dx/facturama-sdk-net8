namespace Facturama.Sdk.Core.Abstractions
{
    public interface IExample
    {
        string Name { get; }
        string Description { get; }
        Task ExecuteAsync();
    }
}
