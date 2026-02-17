using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Facturama.Sdk.Samples.ConsoleApp.Helpers
{
    public static class ConsoleHelper
    {
        private static readonly JsonSerializerOptions Options =
        new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition =
                System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public static void Print(object obj)
        {
            var json = JsonSerializer.Serialize(obj, Options);
            Console.WriteLine(json);
        }
    }
}
