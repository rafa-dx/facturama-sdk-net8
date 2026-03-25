using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Enums;
using Facturama.Sdk.Core.Models.Cfdi;
using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Samples.ConsoleApp.Helpers;


namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class CfdiExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "7";
        public string Description => "CRUD  CFDI";

        public CfdiExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            Console.WriteLine("\n--- Ejemplo de creación de CFDI ---");
            try
            {
                await CreateCfdiExample();
                await ConsultExample();
                await ListCfdiExample();
                await StatusSatExample();
                await DowndloadPdfExample();
                await CancelExample();
                await SendEmailExample();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear CFDI: {ex.Message}");
            }
        }

        public async Task CreateCfdiExample()
        {
            Console.WriteLine("Creando un CFDI de ejemplo...");
            var cfdiRequest = new Core.Models.Request.CfdiRequest
            {
                NameId = "1",
                Folio = "99",
                Serie = "FAC",
                CfdiType = "I",
                PaymentForm = "01",
                PaymentMethod = "PUE",
                ExpeditionPlace = "78000",
                OrderNumber = "TEST-001",
                Currency = "MXN",
                Date = null,
                PaymentConditions = "CREDITO A SIETE DIAS",
                Observations = "Elemento Observaciones solo visible en PDF",
                Receiver = new Receiver
                {
                    Rfc = "URE180429TM6",
                    Name = "UNIVERSIDAD ROBOTICA ESPAÑOLA",
                    CfdiUse = "G03",
                    FiscalRegime = "601",
                    TaxZipCode = "86991",
                    /*
                    Address = new Address                       // El nodo Address es opcional (puedes colocarlo nulo o no colocarlo). En el caso de no colcoarlo, tomará la correspondiente al RFC en el catálogo de clientes
                    {
                        Street = "Avenida de los pinos",
                        ExteriorNumber = "110",
                        InteriorNumber = "A",
                        Neighborhood = "Las villerías",
                        ZipCode = "78000",
                        Municipality = "San Luis Potosí",
                        State = "San Luis Potosí",
                        Country = "México"
                    }*/
                },
                Items = new List<Item>
                {
                    new Item
                    {
                        ProductCode = "10101504",
                        UnitCode = "MTS",
                        Unit = "NO APLICA",
                        Description = "Estudios de laboratorio",
                        IdentificationNumber = null,
                        Quantity = 2.0m,
                        Discount = 0.0m,
                        UnitPrice = 50.0m,
                        Subtotal = 100.0m,
                        TaxObject="02",
                        Taxes=new List<Tax>
                        {
                            new Tax
                            {
                                Name = "IVA",
                                Rate = 0.16m,
                                Total = 16.0m,
                                Base = 100.00m,
                                IsRetention = false
                            }

                        },
                        Total=116.00m,
                        NumerosPedimento = new List<string>()
                        {
                            "21  47  3807  8003832",
                            "21  47  3807  8003832"
                        },
                        PropertyTaxIDNumber = new List<string>()
                        {
                            "12345678",
                            "87654321"
                         }
                    }
                }
            };
            var response = await _facturama.Cfdis.CreateAsync(cfdiRequest);
            ConsoleHelper.Print(response);
            Console.ReadLine();

        }

        public async Task ConsultExample()
        {
            Console.WriteLine("ejemplo de consulta de CFDI...");

            var consultResponse = await _facturama.Cfdis.GetAsync("8-EspIN3oKrMFj_ROmIvSw2");
            ConsoleHelper.Print(consultResponse);
            Console.WriteLine(consultResponse.Id);
            Console.ReadLine();

        }
        public async Task ListCfdiExample()
        {
            Console.WriteLine("Ejemplo de filtrado de facturas");

            var CfdiFiltros = new CfdiFilter
            {
                Type = "issued",
                FolioStart = -1,
                FolioEnd = -1,
                Rfc = null,
                DateStart = null,
                DateEnd = null,
                Status = "all",
                OrderNumber = null,
                TaxEntityName = null,
                IdBranch = null,
                Serie = null,
                Id = null,
                InvoiceType = null,
                PaymentMethod = null,
                RfcIssuer = null,
                Page = 0,
                keyword = null,
            };
            var response = await _facturama.Cfdis.ListAsync(CfdiFiltros);
            Console.WriteLine(response);
            ConsoleHelper.Print(response);


        }

        public async Task StatusSatExample()
        {
            Console.WriteLine("Ejemplo de consulta de estatus SAT de CFDI...");
            var statusFilter = new CfdiStatusParams
            {
                Uuid = "27568D31-7E57-442F-BA77-798CBF30BD7D",
                ReceiverRfc = "URE180429TM6",
                IssuerRfc = "AAA010101AAA",
                Total = "116.00"

            };
            var response = await _facturama.Cfdis.GetStatusAsync(statusFilter);
        }

        public async Task DowndloadPdfExample()
        {
            Console.WriteLine("Ejemplo de descarga de PDF de CFDI...");
            var response = await _facturama.Cfdis.DownloadFileAsync("pdf", "issued", "FMO0tMYhQBddZyTxcDXtFA2");
            ConsoleHelper.Print(response);
        }

        public async Task DowndloadXmlExample()
        {
            Console.WriteLine("Ejemplo de descarga de PDF de CFDI...");
            var response = await _facturama.Cfdis.DownloadFileAsync("xml", "issued", "FMO0tMYhQBddZyTxcDXtFA2");
            ConsoleHelper.Print(response);
        }

        public async Task CancelExample()
        {
            Console.WriteLine("Ejemplo de cancelación de CFDI...");
            var response = await _facturama.Cfdis.CancelAsync("25ec8ZHWJM2VxvSy6sGkdw2", "issued", "02", null);
            ConsoleHelper.Print(response);

        }

        public async Task SendEmailExample()
        {
            Console.WriteLine("Ejemplo de envío de CFDI por correo electrónico...");
            var response = await _facturama.Cfdis.SendByEmailAsync("s1L_Gj2Q1kc8GS8PCM4CWg2","rafael@facturama.mx", "issued" );
            ConsoleHelper.Print(response);
        }
    }
}
