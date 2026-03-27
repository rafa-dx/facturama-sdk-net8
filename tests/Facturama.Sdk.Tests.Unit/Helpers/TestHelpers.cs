using Facturama.Sdk.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Facturama.Sdk.Tests.Unit.Helpers;

public static class TestHelpers
{
    /// <summary>
    /// Crea opciones de Facturama para testing.
    /// </summary>
    public static IOptions<FacturamaOptions> CreateOptions()
    {
        var options = new FacturamaOptions
        {
            Username = "sdkpruebas",
            Password = "password",
            Environment = Core.Enums.FacturamaEnvironment.Sandbox,
            HttpClient = new HttpClientConfiguration
            {
                Timeout = TimeSpan.FromSeconds(30)
            },
            RetryPolicy = new RetryPolicyConfiguration
            {
                MaxRetries = 3
            }
        };
        return Options.Create(options);
    }

    /// <summary>
    /// Crea un logger fake para testing.
    /// </summary>
    public static ILogger<T> CreateLogger<T>()
    {
        return NullLogger<T>.Instance;
    }

    /// <summary>
    /// Crea un logger factory fake.
    /// </summary>
    public static ILoggerFactory CreateLoggerFactory()
    {
        return NullLoggerFactory.Instance;
    }

}
