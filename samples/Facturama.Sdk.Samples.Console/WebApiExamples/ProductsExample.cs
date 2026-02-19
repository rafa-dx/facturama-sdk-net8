using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Exceptions;
using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Samples.ConsoleApp.Helpers;
using FacturamaAPI.src.Facturama.Sdk.Core.Abstractions;
using Microsoft.VisualBasic;

namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class ProductsExample : IExample
    {

        private readonly IFacturamaClient _facturama;

        public string Name => "2";
        public string Description => "CRUD productos";

        public ProductsExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            System.Console.WriteLine("\n--- CRUD productos ---");

            try
            {
                //await ListProductsExample();
                //await CreateProductExample();
                //await ListPagedProductsExample();
                //await UpdateProductExample();
                //await FindProductByIdExample();
                //await DeleteProductExample();
            }
            catch (FacturamaException ex)
            {
                System.Console.WriteLine($"Error al listar productos: {ex.Message}");

            }
        }

        public async Task ListProductsExample()
        {
            Console.WriteLine("Listando solo los primeros 100 productos...");

            var products = await _facturama.Products.ListAsync();

            Console.WriteLine($"Total de productos: {products.Count}");

            foreach (var product in products)
            {
                Console.WriteLine($"  - [{product.Id}] {product.Name} ({product.CodeProdServ}) - {product.Description}");
            }

        }

        public async Task CreateProductExample()
        {
            Console.WriteLine("Creando un nuevo producto...");

            var newProduct = new Core.Models.Request.ProductRequest
            {
                Name = "Sitio Web CMS",
                Description = "Producto de prueba solo IVA",
                CodeProdServ = "43232408",
                Unit = "Servicio",
                UnitCode = "E48",
                IdentificationNumber = "WEB003",
                Price = 999.9999M,
                ObjetoImp = "02",
                Taxes = new[] { new Tax

                    {
                        Name = "IVA",
                        Rate = 0.16M,
                        IsRetention = false,
                        IsFederalTax = true
                    }
                },
                CuentasPredial = new[]
                {
                    "123456789",
                    "987654321"
                }
            };

            var request = await _facturama.Products.CreateAsync(newProduct);
            ConsoleHelper.Print(request);
        }

        public async Task ListPagedProductsExample()
        {
            Console.WriteLine("Listado de forma paginada de los productos");

            var productsPage = await _facturama.Products.ListPaginatedAsync(start: 0, length: 10);

            Console.WriteLine($"Total de productos: {productsPage.TotalRecords}");

            ConsoleHelper.Print(productsPage);

        }

        public async Task UpdateProductExample()
        {
            Console.WriteLine("Actualizando un producto...");
            var IdProduct = "MMUKq-333R30ybL6fUP84A2";
            var newProduct = new Core.Models.Request.ProductRequest
            {
                Id = IdProduct,
                Name = "Sitio Web CMS modificado",
                Description = "Producto de prueba solo IVA",
                CodeProdServ = "43232408",
                Unit = "Servicio",
                UnitCode = "E48",
                IdentificationNumber = "WEB003",
                Category = "General",
                CuentaPredial = "1234567890",
                Price = 999.9999M,
                ObjetoImp = "02",
                Taxes = new[] { new Tax

                    {
                        Name = "IVA",
                        Rate = 0.16M,
                        IsRetention = false,
                        IsFederalTax = true
                    }
                }

            };

            var request = await _facturama.Products.UpdateAsync(IdProduct, newProduct);
        }


        public async Task FindProductByIdExample()
        {
            var IdProduct = "MMUKq-333R30ybL6fUP84A2";

            var request = await _facturama.Products.GetAsync(IdProduct);

            ConsoleHelper.Print(request);
        }

        public async Task DeleteProductExample()
        {
            var IdProduct = "bwgjY-M5QA9QMUQntGDvnQ2";
            await _facturama.Products.DeleteAsync(IdProduct);
            Console.WriteLine($"Producto con ID {IdProduct} eliminado correctamente.");

        }
    }
}
