using Facturama.Sdk.Core.Abstractions;
using Facturama.Sdk.Core.Models.Responses;


namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class SuscriptionPlanExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "5";

        public string Description => "Consult suscripción plan";

        public SuscriptionPlanExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            System.Console.WriteLine("\n--- Consult suscripción plan ---");
            try
            {
                await GetSuscriptionPlanExample();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error al consultar el plan de suscripción: {ex.Message}");
            }
        }

        public async Task GetSuscriptionPlanExample()
        {
            Console.WriteLine("Consultando el plan de suscripción...");
            var plan = await _facturama.SuscriptionPlans.GetAsync();
            Console.WriteLine($"Plan: {plan.Plan}");
            Console.WriteLine($"CurrentFolios: {plan.CurrentFolios}");
            Console.WriteLine($"CreationDate: {plan.ExpirationDate}");
            Console.WriteLine($"ExpirationDate: {plan.ExpirationDate}");
        }
    }
}
