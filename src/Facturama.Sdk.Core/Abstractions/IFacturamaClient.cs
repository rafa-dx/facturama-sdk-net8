namespace Facturama.Sdk.Core.Abstractions
{
    public interface IFacturamaClient
    {
        IClientService Clients { get; }
        IProductService Products { get; }
        IBranchOfficeService BranchOffices { get; }
        ISeriesService Series { get; }
        ISuscriptionPlanService SuscriptionPlans { get; }
        ICatalogService Catalogs { get; }

        ICfdiService Cfdis { get; }
        ICfdiLiteService CfdiLite { get; }

        IRetentionService Retention { get; }


    }
}
