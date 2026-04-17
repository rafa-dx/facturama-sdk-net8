using Facturama.Sdk.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class CatalogExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "6";
        public string Description => "Catálogos";

        public CatalogExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            System.Console.WriteLine("\n--- Catálogos de códigos postales ---");
            try
            {
                await GetPostalCodeExample();
                await GetRelationTypes();
                await GetCountries();
                await GetStates();
                await GetMunicipalities();
                await GetLocalities();
                await GetCfdiUses();
                await GetUnits();
                await GetProductsAndServices();
                await GetNameIds();
                await GetCurrencies();
                await GetBanks();
                await GetPaymentForms();
                await GetPaymentMethods();
                await GetCfdiTypes();
                await GetFiscalRegimens();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error al obtener información del código postal: {ex.Message}");
            }
        }

        public async Task GetPostalCodeExample()
        {
            Console.WriteLine("Obteniendo información de un código postal...");
            string postalCode = "78000"; // Código postal a buscar
            var result = await _facturama.Catalogs.GetPostalCodeAsync(postalCode);
            Console.WriteLine($"Código Postal: {result.FirstOrDefault()?.Name}");
            Console.WriteLine($"Estado: {result.FirstOrDefault()?.StateCode}");
        }

        public async Task GetRelationTypes()
        {
            Console.WriteLine("Obteniendo tipos de relación para CFDI...");
            var relationTypes = await _facturama.Catalogs.GetRelationTypesAsync();
            foreach (var relationType in relationTypes)
            {
                Console.WriteLine($"Nombre: {relationType.Name}, Valor: {relationType.Value}");
            }
        }
        public async Task GetCountries()
        {
            Console.WriteLine("Obteniendo catálogo de países para CFDI...");
            var continentCatalog = await _facturama.Catalogs.GetCountriesAsync();
            foreach (var country in continentCatalog)
            {
                Console.WriteLine($"Nombre: {country.Name}, Valor: {country.Value}");
            }
        }

        public async Task GetStates()
        {
            Console.WriteLine("Obteniendo catálogo de estados para CFDI...");
            string code = "MEX"; // Código del país para filtrar estados
            var statesCatalog = await _facturama.Catalogs.GetStatesAsync(code);
            foreach (var state in statesCatalog)
            {
                Console.WriteLine($"Nombre: {state.Name}, Valor: {state.Value}");
            }
        }

        public async Task GetMunicipalities()
        {
            Console.WriteLine("Obteniendo catálogo de municipios para CFDI...");
            string code = "SLP"; // Código del estado para filtrar municipios
            var municipalitiesCatalog = await _facturama.Catalogs.GetMunicipalitiesAsync(code);
            foreach (var municipality in municipalitiesCatalog)
            {
                Console.WriteLine($"Nombre: {municipality.Name}, Valor: {municipality.Value}");
            }
        }

        public async Task GetLocalities()
        {
            Console.WriteLine("Obteniendo catálogo de localidades para CFDI...");
            string code = "SLP"; // Código del estado para filtrar localidades
            var localitiesCatalog = await _facturama.Catalogs.GetLocalitiesAsync(code);
            foreach (var locality in localitiesCatalog)
            {
                Console.WriteLine($"Nombre: {locality.Name}, Valor: {locality.Value}");
            }
        }

        public async Task GetCfdiUses()
        {
            Console.WriteLine("Obteniendo catálogo de usos de CFDI...");
            var cfdiUsesCatalog = await _facturama.Catalogs.GetCfdiUsesAsync();
            foreach (var cfdiUse in cfdiUsesCatalog)
            {
                Console.WriteLine($"Nombre: {cfdiUse.Name}, Valor: {cfdiUse.Value}");
            }
        }

        public async Task GetUnits()
        {
            Console.WriteLine("Obteniendo catálogo de unidades para CFDI...");
            var unitsCatalog = await _facturama.Catalogs.GetUnitsAsync(null);
            foreach (var unit in unitsCatalog)
            {
                Console.WriteLine($"Nombre: {unit.Name}, Valor: {unit.Value}");
            }
        }

        public async Task GetProductsAndServices()
        {
            Console.WriteLine("Obteniendo catálogo de productos para CFDI...");
            var productsCatalog = await _facturama.Catalogs.GetProductsServicesAsync("desarrollo");
            foreach (var product in productsCatalog)
            {
                Console.WriteLine($"Nombre: {product.Name}, Valor: {product.Value}");
            }
        }

        public async Task GetNameIds()
        {
            Console.WriteLine("Obteniendo catalogo de nombres de CFDIs");
            var NameIdCatalog = await _facturama.Catalogs.GetNameIdsAsync();
            foreach (var nameId in NameIdCatalog)
            {
                Console.WriteLine($"Nombre: {nameId.Name}, Valor: {nameId.Value}");
            }
        }

        public async Task GetCurrencies()
        {

            Console.WriteLine("Obteniendo catálogo de monedas para CFDI...");
            var currenciesCatalog = await _facturama.Catalogs.GetCurrenciesAsync("mexicano");
            foreach (var currency in currenciesCatalog)
            {
                Console.WriteLine($"Nombre: {currency.Name}, Valor: {currency.Value}");

            }
        }

        public async Task GetBanks()
        {
            Console.WriteLine("Obteniendo catálogo de bancos para CFDI...");
            var banksCatalog = await _facturama.Catalogs.GetBanksAsync();
            foreach (var bank in banksCatalog)
            {
                Console.WriteLine($"Nombre: {bank.Name}, Valor: {bank.Value}");
            }
        }

        public async Task GetPaymentForms()
        {
            Console.WriteLine("Obteniendo catálogo de formas de pago para CFDI...");
            var paymentFormsCatalog = await _facturama.Catalogs.GetPaymentFormsAsync();
            foreach (var paymentForm in paymentFormsCatalog)
            {
                Console.WriteLine($"Nombre: {paymentForm.Name}, Valor: {paymentForm.Value}");
            }
        }

        public async Task GetPaymentMethods()
        {
            Console.WriteLine("Obteniendo catálogo de métodos de pago para CFDI...");
            var paymentMethodsCatalog = await _facturama.Catalogs.GetPaymentMethodsAsync();
            foreach (var paymentMethod in paymentMethodsCatalog)
            {
                Console.WriteLine($"Nombre: {paymentMethod.Name}, Valor: {paymentMethod.Value}");
            }
        }

        public async Task GetCfdiTypes()
        {
            Console.WriteLine("Obteniendo catálogo de tipos de CFDI...");
            var cfdiTypesCatalog = await _facturama.Catalogs.GetCfdiTypesAsync();
            foreach (var cfdiType in cfdiTypesCatalog)
            {
                Console.WriteLine($"Nombre: {cfdiType.Name}, Valor: {cfdiType.Value}");
            }
        }

        public async Task GetFiscalRegimens()
        {
            Console.WriteLine("Obteniendo catálogo de regímenes fiscales para CFDI...");
            var fiscalRegimensCatalog = await _facturama.Catalogs.GetFiscalRegimensAsync("EKU9003173C9");
            foreach (var fiscalRegimen in fiscalRegimensCatalog)
            {
                Console.WriteLine($"Nombre: {fiscalRegimen.Name}, Valor: {fiscalRegimen.Value}");
            }
        }


        }

}
