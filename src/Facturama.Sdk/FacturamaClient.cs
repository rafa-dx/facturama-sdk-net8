using Facturama.Sdk.Configuration;
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Enums;
using Facturama.Sdk.Core.Models.Responses.Catalogs;
using Facturama.Sdk.Services;
using FacturamaAPI.src.Facturama.Sdk.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Facturama.Sdk;

/// <summary>
/// Cliente principal para interactuar con la API de Facturama.
/// Punto de entrada para todos los servicios del SDK.
/// </summary>
public sealed class FacturamaClient : IFacturamaClient //, IDisposable
{
    private readonly ILogger<FacturamaClient> _logger;

    public IClientService Clients { get; }
    public IProductService Products { get; }
    public ICfdiService Cfdis { get; }
    public IBranchOfficeService BranchOffices { get; }
    public ISeriesService Series { get; }
    public ISuscriptionPlanService SuscriptionPlans { get; }
    public ICatalogService Catalogs { get; }
    public ICfdiLiteService CfdiLite { get; }

    public IRetentionService Retention { get; }

    public FacturamaClient(
        IClientService clients,
        IProductService products,
        ICfdiService cfdis,
        IBranchOfficeService branchOffices,
        ISeriesService series,
        ISuscriptionPlanService suscriptionPlans,
        ICatalogService catalogs,
        ICfdiLiteService cfdiLite,
        IRetentionService retention,
        ILogger<FacturamaClient> logger)
    {
        Clients = clients;
        Products = products;
        Cfdis = cfdis;
        BranchOffices = branchOffices;
        Series = series;
        SuscriptionPlans = suscriptionPlans;
        Catalogs = catalogs;
        CfdiLite = cfdiLite;
        Retention = retention;
        _logger = logger;

        _logger.LogInformation("FacturamaClient inicializado correctamente");
    }

}