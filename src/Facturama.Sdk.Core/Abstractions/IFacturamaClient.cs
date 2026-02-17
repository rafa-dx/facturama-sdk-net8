namespace Facturama.Sdk.Core.Abstractions
{
    public interface IFacturamaClient
    {
        IClientService Clients { get; }
        IProductService Products { get; }
        //ICfdiService Cfdis { get; }
        //IBranchOfficeService BranchOffices { get; }

    }
}
