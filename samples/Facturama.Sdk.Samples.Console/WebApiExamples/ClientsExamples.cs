using Facturama.Sdk.Samples.ConsoleApp.Helpers;
using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Common;
using FacturamaAPI.src.Facturama.Sdk.Core.Abstractions;
using System.Security.Cryptography.X509Certificates;

namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class ClientsExamples : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "1";
        public string Description => "CRUD clientes";

        public ClientsExamples(IFacturamaClient facturama)
        {
            _facturama = facturama;

        }
        public async Task ExecuteAsync()
        {
            System.Console.WriteLine("\n--- CRUD clientes ---");

            try
            {
                //await ListClientsExample();
                //await CreateClientExample();
                //await ListPagedClientsExample();
                //await UpdateClientExample();
                //await FindClientByRfcExample();
                //await GetClientByIdExample();
                //await DeleteClientExample();


            }
            catch (FacturamaException ex)
            {
                System.Console.WriteLine($"Error al listar clientes: {ex.Message}");
            }

        }

        public async Task ListClientsExample()
        {


            Console.WriteLine("Listando solo los primeros 100 clientes...");


            var clients = await _facturama.Clients.ListAsync();

            Console.WriteLine($"Total de clientes: {clients.Count}");

            foreach (var client in clients)
            {
                System.Console.WriteLine($"  - [{client.Id}] {client.Name} ({client.Rfc}) - {client.Email}");
            }

        }

        public async Task CreateClientExample()
        {
            Console.WriteLine("\nCreando un nuevo cliente...");
            var newClientRequest = new Core.Models.Request.ClientRequest
            {
                Id = "",
                Rfc = "URE180429TM6",
                Name = "UNIVERSIDAD ROBOTICA ESPAÑOLA",
                FiscalRegime = "601",
                CfdiUse = "G03",
                TaxResidence = "30230",
                Email = "ejemplo@ejemplo.mx",
                NumRegIdTrib = "131494-1055",
                EmailOp1 = null,
                TaxZipCode = "30230",
                Address = new Address
                {
                    Country = "MEXICO",
                    ExteriorNumber = "1230",
                    InteriorNumber = "B",
                    Locality = "San Luis",
                    Municipality = "San Luis Potosí",
                    Neighborhood = "Lomas Bonitas",
                    State = "San Luis Potosí",
                    Street = "Cañada de Lobos",
                    ZipCode = "30230"
                },
            };
            var request = await _facturama.Clients.CreateAsync(newClientRequest);

            ConsoleHelper.Print(request);


        }

        public async Task ListPagedClientsExample()
        {
            Console.WriteLine("Listando de forma paginada los clientes...");

            var clientsPage = await _facturama.Clients.ListPaginatedAsync(start: 0, length: 10);

            ConsoleHelper.Print(clientsPage);
        }

        public async Task UpdateClientExample()
        {
            Console.WriteLine("\nActualizando un cliente...");
            var updateClientRequest = new Facturama.Sdk.Core.Models.Request.ClientRequest
            {
                Id = "J_uWmWVdg-DJLoR1noHAbQ2",
                Rfc = "FUNK671228PH6",
                Name = "KARLA FUENTE NOLASCO",
                FiscalRegime = "605",
                CfdiUse = "S01",
                TaxResidence = "01160",
                Email = "ejemplo@ejemplo.mx",
                EmailOp1 = null,
                TaxZipCode = "01160",
                NumRegIdTrib = "131494-1055",
                Address = new Address
                {
                    Country = "MEXICO",
                    ExteriorNumber = "1230",
                    InteriorNumber = "B",
                    Locality = "San Luis",
                    Municipality = "San Luis Potosí",
                    Neighborhood = "Lomas Bonitas",
                    State = "San Luis Potosí",
                    Street = "Cañada de Lobos",
                    ZipCode = "01160"
                },
            };
            var request = await _facturama.Clients.UpdateAsync(updateClientRequest.Id, updateClientRequest);

            ConsoleHelper.Print(request);
        }

        public async Task FindClientByRfcExample()
        {
            Console.WriteLine("\nBuscando un cliente por RFC...");
            var rfc = "FUNK671228PH6";
            var client = await _facturama.Clients.ListAsync(rfc);
            if (client != null)
            {
                ConsoleHelper.Print(client);
            }
            else
            {
                Console.WriteLine($"No se encontró un cliente con RFC {rfc}");
            }
        }

        public async Task DeleteClientExample()
        {
            Console.WriteLine("\nEliminando un cliente...");
            var clientId = "J_uWmWVdg-DJLoR1noHAbQ2";
            await _facturama.Clients.DeleteAsync(clientId);
            Console.WriteLine($"Cliente con ID {clientId} eliminado.");
        }
        public async Task GetClientByIdExample()
        {
            Console.WriteLine("\nObteniendo un cliente por ID...");
            var clientId = "0VKYoFmuf-cB-pzbm76rTA2";
            var client = await _facturama.Clients.GetAsync(clientId);
            if (client != null)
            {
                ConsoleHelper.Print(client);
            }
            else
            {
                Console.WriteLine($"No se encontró un cliente con ID {clientId}");
            }
        }
    }
 }
