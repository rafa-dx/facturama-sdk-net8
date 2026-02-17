using Facturama.Sdk.Configuration;
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Facturama.Sdk;

/// <summary>
/// Cliente principal para interactuar con la API de Facturama.
/// Punto de entrada para todos los servicios del SDK.
/// </summary>
public sealed class FacturamaClient : IFacturamaClient, IDisposable
{
    private readonly ILogger<FacturamaClient> _logger;
    private readonly Lazy<IClientService> _clients;
    private readonly Lazy<IProductService> _products;
    private readonly Lazy<ICfdiService> _cfdis;
    private readonly Lazy<IBranchOfficeService> _branchOffices;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="FacturamaClient"/> con Dependency Injection.
    /// </summary>
    /// <param name="httpClient">Cliente HTTP configurado con autenticación.</param>
    /// <param name="options">Opciones de configuración de Facturama.</param>
    /// <param name="logger">Logger para diagnósticos.</param>
    /// <param name="loggerFactory">Factory para crear loggers de servicios.</param>
    public FacturamaClient(
        IFacturamaHttpClient httpClient,
        IOptions<FacturamaOptions> options,
        ILogger<FacturamaClient> logger,
        ILoggerFactory loggerFactory)
    {
        ArgumentNullException.ThrowIfNull(httpClient);
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(loggerFactory);

        _logger = logger;

        var facturamaOptions = options.Value;
        facturamaOptions.Validate(); // Validar configuración

        _logger.LogInformation(
            "Inicializando FacturamaClient para ambiente: {Environment}",
            facturamaOptions.Environment);

        // Lazy initialization para crear servicios solo cuando se acceden
        _clients = new Lazy<IClientService>(() =>
            new ClientService(
                httpClient,
                loggerFactory.CreateLogger<ClientService>()));
        
        _products = new Lazy<IProductService>(() =>
            new ProductService(
                httpClient,
                loggerFactory.CreateLogger<ProductService>()));
        /*

        _cfdis = new Lazy<ICfdiService>(() =>
            new CfdiService(
                httpClient,
                loggerFactory.CreateLogger<CfdiService>()));

        _branchOffices = new Lazy<IBranchOfficeService>(() =>
            new BranchOfficeService(
                httpClient,
                loggerFactory.CreateLogger<BranchOfficeService>()));
        */
        _logger.LogDebug("FacturamaClient inicializado correctamente");
    }

    /// <summary>
    /// Servicio para gestionar clientes.
    /// </summary>
    public IClientService Clients => _clients.Value;

    /// <summary>
    /// Servicio para gestionar productos.
    /// </summary>
    public IProductService Products => _products.Value;

    /// <summary>
    /// Servicio para gestionar CFDIs (facturas).
    /// </summary>
    //public ICfdiService Cfdis => _cfdis.Value;

    /// <summary>
    /// Servicio para gestionar sucursales.
    /// </summary>
    //public IBranchOfficeService BranchOffices => _branchOffices.Value;

    /// <summary>
    /// Libera los recursos utilizados por el cliente.
    /// </summary>
    public void Dispose()
    {
        _logger.LogDebug("FacturamaClient disposed");
    }
}

// Ejemplo de uso con Dependency Injection:
//
// // En Program.cs o Startup.cs
// builder.Services.AddFacturama(options =>
// {
//     options.Username = builder.Configuration["Facturama:Username"];
//     options.Password = builder.Configuration["Facturama:Password"];
//     options.Environment = FacturamaEnvironment.Sandbox;
// });
//
// // En tu servicio o controlador
// public class InvoiceService
// {
//     private readonly IFacturamaClient _facturama;
//
//     public InvoiceService(IFacturamaClient facturama)
//     {
//         _facturama = facturama;
//     }
//
//     public async Task CreateInvoice()
//     {
//         // Crear cliente
//         var client = await _facturama.Clients.CreateAsync(new CreateClientRequest
//         {
//             Rfc = "XAXX010101000",
//             Name = "Cliente de Prueba",
//             Email = "cliente@example.com",
//             FiscalRegime = "601",
//             TaxZipCode = "78000",
//             CfdiUse = "G03"
//         });
//
//         // Crear producto
//         var product = await _facturama.Products.CreateAsync(new CreateProductRequest
//         {
//             Name = "Servicio de Consultoría",
//             UnitPrice = 1000.00m,
//             TaxIncluded = false
//         });
//
//         // Crear CFDI
//         var cfdi = await _facturama.Cfdis.CreateAsync(new CreateCfdiRequest
//         {
//             Receiver = client,
//             Items = new[] { product }
//         });
//     }
// }

// Ejemplo de uso sin Dependency Injection (builder pattern):
//
// var client = new FacturamaClientBuilder()
//     .WithCredentials("usuario", "contraseña")
//     .UseEnvironment(FacturamaEnvironment.Sandbox)
//     .WithTimeout(TimeSpan.FromSeconds(45))
//     .Build();
//
// var clients = await client.Clients.ListAsync();

// Notas de implementación:
//
// 1. Lazy Initialization:
//    - Los servicios se crean solo cuando se acceden por primera vez
//    - Reduce el tiempo de inicialización si solo usas algunos servicios
//    - Thread-safe por diseño de Lazy<T>
//
// 2. IDisposable:
//    - Implementado para compatibilidad con using statements
//    - En DI con Scoped/Singleton, el contenedor maneja el Dispose
//    - Actualmente no hay recursos que disponer, pero preparado para futuro
//
// 3. Validación:
//    - Se valida la configuración en el constructor
//    - Falla rápido si la configuración es inválida
//    - Evita errores en tiempo de ejecución
//
// 4. Logging:
//    - LogInformation en inicialización
//    - LogDebug en dispose
//    - Cada servicio tiene su propio logger tipado
//
// 5. Extensibilidad:
//    - Fácil agregar nuevos servicios (solo agregar propiedad Lazy)
//    - Servicios desacoplados entre sí
//    - Cada servicio puede evoluionar independientemente
//
// 6. Thread-safety:
//    - Lazy<T> es thread-safe por defecto
//    - Los servicios son stateless
//    - Puede usarse de forma concurrente sin problemas
//
// 7. Dependencias:
//    - IFacturamaHttpClient: inyectado, configurado en DI
//    - IOptions<FacturamaOptions>: configuración
//    - ILogger: logging
//    - ILoggerFactory: para crear loggers de servicios