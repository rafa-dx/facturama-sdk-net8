using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Cfdi;
using Facturama.Sdk.Core.Models.Filters;
using Facturama.Sdk.Core.Models.Requests;
using Facturama.Sdk.Core.Models.Retentions;
using Facturama.Sdk.Core.Models.Retentions.Complements;
using Facturama.Sdk.Samples.ConsoleApp.Helpers;


namespace Facturama.Sdk.Samples.ConsoleApp.RetentionExample
{
    public class RetentionExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "9";
        public string Description => "CRUD Retenciones";

        public RetentionExample(IFacturamaClient client)
        {
            _facturama = client;
        }

        public async Task ExecuteAsync()
        {
            Console.WriteLine("\n--- Ejemplo de creación de retention ---");
            try
            {
                await CreateRetentionExample();
                await CreateRetentionPTExample();
                await ConsultExample();
                await ListRetentionExample();
                await DowndloadPdfExample();
                await CancelExample();
                await SendEmailExample();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear CFDI: {ex.Message}");
            }
        }

        public async Task CreateRetentionExample()
        {
            Console.WriteLine("Ejemplo de retencion");
            var retentionRequest = new RetentionRequest
            {
                FolioInt = "0001",
                FechaExp = "2026-03-20T12:00:01",
                CveRetenc = "01",
                LugarExpRetenc = "78000",
                Emisor = new Core.Models.Retentions.Emisor
                {
                    RFCEmisor = "EKU9003173C9",
                    NomDenRazSocE = "ESCUELA KEMPER URGATE",
                    RegimenFiscalE = "601"
                },
                Receptor = new Core.Models.Retentions.Receptor
                {
                    Nacionalidad = "Nacional",
                    Nacional = new Core.Models.Retentions.Nacional
                    {
                        RFCRecep = "CACX7605101P8",
                        NomDenRazSocR = "XOCHILT CASAS CHAVEZ",
                        DomicilioFiscalR = "36257"
                    }
                },
                Periodo = new Core.Models.Retentions.Periodo
                {
                    MesIni = "01",
                    MesFin = "01",
                    Ejerc = "2025"
                },
                Totales = new Core.Models.Retentions.Totales
                {
                    montoTotOperacion = 1681.06m,
                    montoTotGrav = 1681.06m,
                    montoTotExent = 0.00m,
                    montoTotRet = 151.29m,
                    ImpRetenidos = new List<ImpRetenido>
                    {
                        new ImpRetenido
                        {
                            BaseRet = 1681.06m,
                            Impuesto = "01",
                            MontoRet = 16.81m,
                            TipoPagoRet = "04"
                        },
                        new ImpRetenido
                        {
                            BaseRet = 268.96m,
                            Impuesto = "02",
                            MontoRet = 134.48m,
                            TipoPagoRet = "01"
                        },

                    }
                }
            };
            var response = await _facturama.Retention.CreateAsync(retentionRequest);
            ConsoleHelper.Print(response);
        }

        public async Task CreateRetentionPTExample()
        {
            Console.WriteLine("Ejemplo de retencion");
            var retentionRequest = new RetentionRequest
            {
                FolioInt = "0001",
                FechaExp = "2026-03-22T12:00:01",
                CveRetenc = "26",
                LugarExpRetenc = "78000",
                Emisor = new Core.Models.Retentions.Emisor
                {
                    RFCEmisor = "EKU9003173C9",
                    NomDenRazSocE = "ESCUELA KEMPER URGATE",
                    RegimenFiscalE = "601"
                },
                Receptor = new Core.Models.Retentions.Receptor
                {
                    Nacionalidad = "Nacional",
                    Nacional = new Core.Models.Retentions.Nacional
                    {
                        RFCRecep = "CACX7605101P8",
                        NomDenRazSocR = "XOCHILT CASAS CHAVEZ",
                        DomicilioFiscalR = "36257"
                    }
                },
                Periodo = new Core.Models.Retentions.Periodo
                {
                    MesIni = "01",
                    MesFin = "01",
                    Ejerc = "2025"
                },
                Totales = new Core.Models.Retentions.Totales
                {
                    montoTotOperacion = 1681.06m,
                    montoTotGrav = 1681.06m,
                    montoTotExent = 0.00m,
                    montoTotRet = 151.29m,
                    ImpRetenidos = new List<ImpRetenido>
                    {
                        new ImpRetenido
                        {
                            BaseRet = 1681.06m,
                            Impuesto = "01",
                            MontoRet = 16.81m,
                            TipoPagoRet = "04"
                        },
                        new ImpRetenido
                        {
                            BaseRet = 268.96m,
                            Impuesto = "02",
                            MontoRet = 134.48m,
                            TipoPagoRet = "01"
                        },

                    }
                },
                Complemento = new Complemento
                {
                    ServiciosPlataformasTecnologicas = new Core.Models.Retentions.Complements.ServiciosPlataformasTecnologicas
                    {
                        Servicios = new List<Core.Models.Retentions.Complements.DetallesDelServicio>
                        {
                            new DetallesDelServicio
                            {
                                ImpuestosTrasladadosdelServicio = new ImpuestosTrasladadosdelServicio
                                {
                                    Base = 1681.06m,
                                    Impuesto = "02",
                                    TipoFactor = "Tasa",
                                    TasaCuota = 0.160000m,
                                    Importe = 268.9696m
                                },
                                ComisionDelServicio = new ComisionDelServicio
                                {
                                    Base = 1681.06m,
                                    Importe = 14.66m
                                },
                                FormaPagoServ = "02",
                                TipoDeServ = "05",
                                FechaServ = "2025-01-01",
                                PrecioServSinIva = 1681.06m


                            }
                        },
                        Periodicidad = "02",
                        NumServ = 1,
                        MontToServSIva = 1681.06m,
                        TotalIvaTrasladado = 268.9696m,
                        TotalIvaRetenido = 134.48m,
                        TotalIsrRetenido = 16.81m,
                        DifIvaEntregadoPrestServ = 134.4896m,
                        MonTotalporUsoPlataforma = 14.66m
                    }
                } 
            };

            
            var response = await _facturama.Retention.CreateAsync(retentionRequest);
            ConsoleHelper.Print(response);
        }

        public async Task ConsultExample()
        {
            var Id = "CSua5JPvL9HNAoWhphJ5Wg2";

            var request = await _facturama.Retention.GetAsync(Id);

            ConsoleHelper.Print(request);
        }

        public async Task ListRetentionExample()
        {
            Console.WriteLine("Listar retenciones");

            var RetentionFilter = new RetentionFilter
            {
                status = "all",
                keyword = "0004"
            };
            var response = await _facturama.Retention.ListAsync(RetentionFilter);

            ConsoleHelper.Print(response);
        }

        public async Task DowndloadPdfExample()
        {
            Console.WriteLine("ejemplo para dedscargar PDFd retenciones");

            var response = await _facturama.Retention.DownloadFileAsync("CSua5JPvL9HNAoWhphJ5Wg2","pdf");

            ConsoleHelper.Print(response);

        }

        public async Task CancelExample()
        {
            Console.WriteLine("Ejemplo Cancelacion retenciones");
            var response = await _facturama.Retention.CancelAsync("O_0PuVO72nvjSKp0mhbNgQ2");
            ConsoleHelper.Print(response);
        }

        public async Task SendEmailExample()
        {
            Console.WriteLine("Ejemplo envio por correo retencion");

            var response = await _facturama.Retention.SendByEmailAsync("CSua5JPvL9HNAoWhphJ5Wg2", "rafael@facturama.mx");
            ConsoleHelper.Print(response);
        }
    }
}
