// Facturama.Sdk.Samples.Console/Program.cs

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FacturamaAPI.src.Facturama.Sdk.Core.Abstractions;
using Microsoft.Extensions.Hosting;
using FacturamaAPI.src.Facturama.Sdk.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Facturama.Sdk.DependencyInjection;
using Facturama.Sdk.Samples.ConsoleApp.WebApiExamples;

// Configurar Host con Dependency Injection
var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Registrar el SDK de Facturama
        services.AddFacturama(context.Configuration);

        // Registrar la aplicación principal
        services.AddTransient<Application>();
        //WebAPIExamples
        //services.AddTransient<ClientExamples>();
        services.AddTransient<IExample, ClientExamples>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
        logging.SetMinimumLevel(LogLevel.Debug);
    })
    .Build();

// Ejecutar la aplicación
var app = host.Services.GetRequiredService<Application>();
await app.RunAsync();

// Clase principal de la aplicación
public class Application
{
    private readonly ILogger<Application> _logger;
    private readonly Dictionary<string, IExample> _examples;


    public Application(ILogger<Application> logger, IEnumerable<IExample> examples)
    {
        _logger = logger;
        _examples = examples.ToDictionary(e => e.Name);
    }

    public async Task RunAsync()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("  SDK de Facturama - Aplicación de Prueba");
        Console.WriteLine("==============================================");
        Console.WriteLine();

        try
        {
            // Menú interactivo
            while (true)
            {
                ShowMenu();
                var option = Console.ReadLine();

                if (option == "0")
                {
                    Console.WriteLine("¡Hasta pronto!");
                    return;
                }

                if (_examples.TryGetValue(option, out var example))
                {
                    await example.ExecuteAsync();
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                }



                Console.WriteLine();
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inesperado en la aplicación");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("Selecciona una opción:");

        foreach (var example in _examples.Values.OrderBy(e => e.Name))
        {
            Console.WriteLine($"  {example.Name}. {example.Description}");
        }
        Console.WriteLine("  0. Salir");
        Console.Write("\nOpción: ");

    }

}