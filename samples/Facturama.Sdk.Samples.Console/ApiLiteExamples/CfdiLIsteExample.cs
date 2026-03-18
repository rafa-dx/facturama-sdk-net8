using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Cfdi;
using Facturama.Sdk.Core.Models.Common;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Request;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Samples.ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Samples.ConsoleApp.ApiLiteExamples
{
    public class CfdiLIsteExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "8";

        public string Description => "Ejemplo de creación de CFDI en APi Multiemisor.";

        public CfdiLIsteExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            Console.WriteLine("\n--- Ejemplo de creación de CFDI en APi Multiemisor ---");
            try
            {
                await UploadCsdApiLiteExample();
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
                Console.WriteLine($"Error al listar CFDI: {ex.Message}");
            }
        }

        public async Task UploadCsdApiLiteExample()
        {
            Console.WriteLine("Subiendo el CSD para el emisor en API Multiemisor ");
            var csdApiLite = new CsdRequest
            {
                Rfc = "EKU9003173C9",
                Certificate = "MIIFsDCCA5igAwIBAgIUMzAwMDEwMDAwMDA1MDAwMDM0MTYwDQYJKoZIhvcNAQELBQAwggErMQ8wDQYDVQQDDAZBQyBVQVQxLjAsBgNVBAoMJVNFUlZJQ0lPIERFIEFETUlOSVNUUkFDSU9OIFRSSUJVVEFSSUExGjAYBgNVBAsMEVNBVC1JRVMgQXV0aG9yaXR5MSgwJgYJKoZIhvcNAQkBFhlvc2Nhci5tYXJ0aW5lekBzYXQuZ29iLm14MR0wGwYDVQQJDBQzcmEgY2VycmFkYSBkZSBjYWxpejEOMAwGA1UEEQwFMDYzNzAxCzAJBgNVBAYTAk1YMRkwFwYDVQQIDBBDSVVEQUQgREUgTUVYSUNPMREwDwYDVQQHDAhDT1lPQUNBTjERMA8GA1UELRMIMi41LjQuNDUxJTAjBgkqhkiG9w0BCQITFnJlc3BvbnNhYmxlOiBBQ0RNQS1TQVQwHhcNMjMwNTE4MTE0MzUxWhcNMjcwNTE4MTE0MzUxWjCB1zEnMCUGA1UEAxMeRVNDVUVMQSBLRU1QRVIgVVJHQVRFIFNBIERFIENWMScwJQYDVQQpEx5FU0NVRUxBIEtFTVBFUiBVUkdBVEUgU0EgREUgQ1YxJzAlBgNVBAoTHkVTQ1VFTEEgS0VNUEVSIFVSR0FURSBTQSBERSBDVjElMCMGA1UELRMcRUtVOTAwMzE3M0M5IC8gVkFEQTgwMDkyN0RKMzEeMBwGA1UEBRMVIC8gVkFEQTgwMDkyN0hTUlNSTDA1MRMwEQYDVQQLEwpTdWN1cnNhbCAxMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtmecO6n2GS0zL025gbHGQVxznPDICoXzR2uUngz4DqxVUC/w9cE6FxSiXm2ap8Gcjg7wmcZfm85EBaxCx/0J2u5CqnhzIoGCdhBPuhWQnIh5TLgj/X6uNquwZkKChbNe9aeFirU/JbyN7Egia9oKH9KZUsodiM/pWAH00PCtoKJ9OBcSHMq8Rqa3KKoBcfkg1ZrgueffwRLws9yOcRWLb02sDOPzGIm/jEFicVYt2Hw1qdRE5xmTZ7AGG0UHs+unkGjpCVeJ+BEBn0JPLWVvDKHZAQMj6s5Bku35+d/MyATkpOPsGT/VTnsouxekDfikJD1f7A1ZpJbqDpkJnss3vQIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQsFAAOCAgEAFaUgj5PqgvJigNMgtrdXZnbPfVBbukAbW4OGnUhNrA7SRAAfv2BSGk16PI0nBOr7qF2mItmBnjgEwk+DTv8Zr7w5qp7vleC6dIsZFNJoa6ZndrE/f7KO1CYruLXr5gwEkIyGfJ9NwyIagvHHMszzyHiSZIA850fWtbqtythpAliJ2jF35M5pNS+YTkRB+T6L/c6m00ymN3q9lT1rB03YywxrLreRSFZOSrbwWfg34EJbHfbFXpCSVYdJRfiVdvHnewN0r5fUlPtR9stQHyuqewzdkyb5jTTw02D2cUfL57vlPStBj7SEi3uOWvLrsiDnnCIxRMYJ2UA2ktDKHk+zWnsDmaeleSzonv2CHW42yXYPCvWi88oE1DJNYLNkIjua7MxAnkNZbScNw01A6zbLsZ3y8G6eEYnxSTRfwjd8EP4kdiHNJftm7Z4iRU7HOVh79/lRWB+gd171s3d/mI9kte3MRy6V8MMEMCAnMboGpaooYwgAmwclI2XZCczNWXfhaWe0ZS5PmytD/GDpXzkX0oEgY9K/uYo5V77NdZbGAjmyi8cE2B2ogvyaN2XfIInrZPgEffJ4AB7kFA2mwesdLOCh0BLD9itmCve3A1FGR4+stO2ANUoiI3w3Tv2yQSg4bjeDlJ08lXaaFCLW2peEXMXjQUk7fmpb5MNuOUTW6BE=",
                PrivateKey = "MIIFDjBABgkqhkiG9w0BBQ0wMzAbBgkqhkiG9w0BBQwwDgQIAgEAAoIBAQACAggAMBQGCCqGSIb3DQMHBAgwggS/AgEAMASCBMh4EHl7aNSCaMDA1VlRoXCZ5UUmqErAbucoZQObOaLUEm+I+QZ7Y8Giupo+F1XWkLvAsdk/uZlJcTfKLJyJbJwsQYbSpLOCLataZ4O5MVnnmMbfG//NKJn9kSMvJQZhSwAwoGLYDm1ESGezrvZabgFJnoQv8Si1nAhVGTk9FkFBesxRzq07dmZYwFCnFSX4xt2fDHs1PMpQbeq83aL/PzLCce3kxbYSB5kQlzGtUYayiYXcu0cVRu228VwBLCD+2wTDDoCmRXtPesgrLKUR4WWWb5N2AqAU1mNDC+UEYsENAerOFXWnmwrcTAu5qyZ7GsBMTpipW4Dbou2yqQ0lpA/aB06n1kz1aL6mNqGPaJ+OqoFuc8Ugdhadd+MmjHfFzoI20SZ3b2geCsUMNCsAd6oXMsZdWm8lzjqCGWHFeol0ik/xHMQvuQkkeCsQ28PBxdnUgf7ZGer+TN+2ZLd2kvTBOk6pIVgy5yC6cZ+o1Tloql9hYGa6rT3xcMbXlW+9e5jM2MWXZliVW3ZhaPjptJFDbIfWxJPjz4QvKyJk0zok4muv13Iiwj2bCyefUTRz6psqI4cGaYm9JpscKO2RCJN8UluYGbbWmYQU+Int6LtZj/lv8p6xnVjWxYI+rBPdtkpfFYRp+MJiXjgPw5B6UGuoruv7+vHjOLHOotRo+RdjZt7NqL9dAJnl1Qb2jfW6+d7NYQSI/bAwxO0sk4taQIT6Gsu/8kfZOPC2xk9rphGqCSS/4q3Os0MMjA1bcJLyoWLp13pqhK6bmiiHw0BBXH4fbEp4xjSbpPx4tHXzbdn8oDsHKZkWh3pPC2J/nVl0k/yF1KDVowVtMDXE47k6TGVcBoqe8PDXCG9+vjRpzIidqNo5qebaUZu6riWMWzldz8x3Z/jLWXuDiM7/Yscn0Z2GIlfoeyz+GwP2eTdOw9EUedHjEQuJY32bq8LICimJ4Ht+zMJKUyhwVQyAER8byzQBwTYmYP5U0wdsyIFitphw+/IH8+v08Ia1iBLPQAeAvRfTTIFLCs8foyUrj5Zv2B/wTYIZy6ioUM+qADeXyo45uBLLqkN90Rf6kiTqDld78NxwsfyR5MxtJLVDFkmf2IMMJHTqSfhbi+7QJaC11OOUJTD0v9wo0X/oO5GvZhe0ZaGHnm9zqTopALuFEAxcaQlc4R81wjC4wrIrqWnbcl2dxiBtD73KW+wcC9ymsLf4I8BEmiN25lx/OUc1IHNyXZJYSFkEfaxCEZWKcnbiyf5sqFSSlEqZLc4lUPJFAoP6s1FHVcyO0odWqdadhRZLZC9RCzQgPlMRtji/OXy5phh7diOBZv5UYp5nb+MZ2NAB/eFXm2JLguxjvEstuvTDmZDUb6Uqv++RdhO5gvKf/AcwU38ifaHQ9uvRuDocYwVxZS2nr9rOwZ8nAh+P2o4e0tEXjxFKQGhxXYkn75H3hhfnFYjik/2qunHBBZfcdG148MaNP6DjX33M238T9Zw/GyGx00JMogr2pdP4JAErv9a5yt4YR41KGf8guSOUbOXVARw6+ybh7+meb7w4BeTlj3aZkv8tVGdfIt3lrwVnlbzhLjeQY6PplKp3/a5Kr5yM0T4wJoKQQ6v3vSNmrhpbuAtKxpMILe8CQoo=",
                PrivateKeyPassword = "12345678a",
            };
            var response = _facturama.CfdiLite.UploadCsdAsync(csdApiLite);
        }

        public async Task CreateCfdiExample() 
        {

            Console.WriteLine("Creando un CFDI de ejemplo ");
            var cfdiRequest = new Core.Models.Request.CfdiLiteRequest
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
                Date = "2026-03-17T21:42:24",
                PaymentConditions = "CREDITO A SIETE DIAS",
                Observations = "Elemento Observaciones solo visible en PDF",
                Issuer = new Issuer
                {
                    Rfc = "EKU9003173C9",
                    Name = "ESCUELA KEMPER URGATE",
                    FiscalRegime= "601"

                },
                Receiver = new Receiver
                {
                    Rfc = "URE180429TM6",
                    Name = "UNIVERSIDAD ROBOTICA ESPAÑOLA",
                    CfdiUse = "G03",
                    FiscalRegime = "601",
                    TaxZipCode = "86991",
                    
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
            var response = await _facturama.CfdiLite.CreateAsync(cfdiRequest, 4);
            ConsoleHelper.Print(response);
            Console.ReadLine();
        }

        public async Task ConsultExample()
        {
            Console.WriteLine("ejemplo de consulta de CFDI...");

            var consultResponse = await _facturama.CfdiLite.GetAsync("itBnQ-qnvtEdMmdeZx4_1Q2");
            ConsoleHelper.Print(consultResponse);
            Console.WriteLine(consultResponse.Id);
            Console.ReadLine();
        }

        public async Task ListCfdiExample()
        {
            Console.WriteLine("Ejemplo de filtrado de facturas");

            var CfdiFiltros = new CfdiFilter
            {
                Type = "issuedLite",
                FolioStart = -1,
                FolioEnd = -1,
                Rfc = null,
                DateStart = null,
                DateEnd = null,
                Status = "all",
                TaxEntityName = null,
                Serie = null,
                Id = null,
                RfcIssuer = null,
                Page = 0,
  
            };
            var response = await _facturama.CfdiLite.ListAsync(CfdiFiltros);
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
            var response = await _facturama.CfdiLite.DownloadFileAsync("pdf", "issuedLite", "itBnQ-qnvtEdMmdeZx4_1Q2");
            ConsoleHelper.Print(response);
        }

        public async Task CancelExample()
        {
            Console.WriteLine("Ejemplo de cancelación de CFDI...");
            var response = await _facturama.CfdiLite.CancelAsync("itBnQ-qnvtEdMmdeZx4_1Q2", "issuedLite", "02", null);
            ConsoleHelper.Print(response);

        }

        public async Task SendEmailExample()
        {
            Console.WriteLine("Ejemplo de envío de CFDI por correo electrónico...");
            var response = await _facturama.CfdiLite.SendByEmailAsync("itBnQ-qnvtEdMmdeZx4_1Q2", "rafael@facturama.mx", "rafael.do@pruebas.com",null,null, "issuedLite");
            ConsoleHelper.Print(response);

        }


    }
}
