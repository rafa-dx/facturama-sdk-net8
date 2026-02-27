using Facturama.Sdk.Core.Abstractions;


namespace Facturama.Sdk.Samples.ConsoleApp.WebApiExamples
{
    public class SerieExample : IExample
    {
        private readonly IFacturamaClient _facturama;

        public string Name => "4";

        public string Description => "CRUD series";

        public SerieExample(IFacturamaClient facturama)
        {
            _facturama = facturama;
        }

        public async Task ExecuteAsync()
        {
            System.Console.WriteLine("\n--- CRUD series ---");
            try
            {
                //await ListSeriesExample();
                //await CreateSerieExample();
                //await DeleteSerieExample();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error al listar series: {ex.Message}");
            }


        }

        public async Task ListSeriesExample()
        {
            Console.WriteLine("Listando de las series de un lugar de expedición...");
            string Id = "GkJL10RzjP7G7-c4zxv9uw2";

            var series = await _facturama.Series.ListSerieAsync(Id);

            Console.WriteLine($"Total de series: {series.Count}");
            foreach (var serie in series)
            {
                Console.WriteLine($"  - [{serie.Name}] {serie.Folio} ({serie.Description})");
            }
        }

        public async Task CreateSerieExample()
        {
            Console.WriteLine("Creando una nueva serie...");
            string Id = "GkJL10RzjP7G7-c4zxv9uw2";
            var serie = await _facturama.Series.CreateSerieAsync(Id, new Core.Models.Request.SerieRequest
            {
                IdBranchOffice = Id,
                Name = "A",
                Description = "Serie A",
                Folio = 1
            });
            Console.WriteLine($"Serie creada: {serie.Name} - {serie.Description}");
        }
    }
}
