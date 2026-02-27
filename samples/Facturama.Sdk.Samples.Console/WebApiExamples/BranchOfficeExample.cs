using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Common;


namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class BranchOfficeExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "3";

        public string Description => "CRUD sucursales";

        public BranchOfficeExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            System.Console.WriteLine("\n--- CRUD sucursales ---");
            try
            {
                await ListBranchOfficesExample();
                await CreateBranchOfficeExample();
                await UpdateBranchOfficeExample();
                await DeleteBranchOfficeExample();

            }
            catch (FacturamaException ex)
            {
                Console.WriteLine($"Error al listar sucursales: {ex.Message}");
            }
        }

        public async Task ListBranchOfficesExample()
        {
            Console.WriteLine("Listando solo las primeras 100 sucursales...");
            var branchOffices = await _facturama.BranchOffices.ListAsync();
            Console.WriteLine($"Total de sucursales: {branchOffices.Count}");
            foreach (var branchOffice in branchOffices)
            {
                Console.WriteLine($"  - [{branchOffice.Id}] {branchOffice.Name}");
            }
        }

        public async Task CreateBranchOfficeExample()
        {
            Console.Write("Creando una nueva sucursal de prueba...");
            var newBranchOffice = new Core.Models.Request.BranchOfficeRequest
            {
                Name = "El sauce",
                Description = "Sucursal del sauce, enfocada en la distribución de agua en garrafón",
                Address = new Address
                {

                    Street = "Av. del Sauce",
                   ExteriorNumber = "120",
                   InteriorNumber = "",
                   Neighborhood = "Las Flores",
                   ZipCode ="78116",
                   Locality = "Localidad",
                   Municipality = "San Luis Potosi",
                   State = "San Luis Potosi",
                   Country = "México"
                  }
            };
            var request = await _facturama.BranchOffices.CreateAsync(newBranchOffice);
            Console.WriteLine($"Sucursal creada: [{request.Id}] {request.Name} ");
        }

        public async Task UpdateBranchOfficeExample()
        {
            var IdBranchOffice = "GzU8suBbDfiee_O5lvGt-A2"; 
            var branchOfficeToUpdate = new Core.Models.Request.BranchOfficeRequest
            {
                Id = IdBranchOffice,
                Name = "El sauce",
                Description = "Sucursal del sauce, enfocada en la distribución de agua en garrafón",
                Address = new Address
                {

                    Street = "Av. del Sauce",
                    ExteriorNumber = "120",
                    InteriorNumber = "",
                    Neighborhood = "Las Flores",
                    ZipCode = "78116",
                    Locality = "Localidad",
                    Municipality = "San Luis Potosi",
                    State = "San Luis Potosi",
                    Country = "México"
                }
            };
            var response = await _facturama.BranchOffices.UpdateAsync( IdBranchOffice, branchOfficeToUpdate);

         
            Console.WriteLine($"Sucursal actualizada: [{response.Id}] {response.Name}");
        }

        public async Task DeleteBranchOfficeExample()
        {
            Console.WriteLine("Eliminando la sucursal de prueba...");
            var idBranchOffice = "FzS_VLdlowXsKANyHqYYkQ2";

            await _facturama.BranchOffices.DeleteAsync(idBranchOffice);
            Console.WriteLine($"Sucursal eliminada: [{idBranchOffice}] ");
        }
    }

    }
