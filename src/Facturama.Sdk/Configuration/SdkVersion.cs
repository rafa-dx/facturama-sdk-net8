using Facturama.Sdk.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Configuration
{
    /// <summary>
    /// Información de versión del SDK
    /// </summary>
    internal class SdkVersion
    {
        /// <summary>
        /// Versión actual del SDK.
        /// </summary>
        public static string Version { get; }

        /// <summary>
        /// User-Agent por defecto.
        /// </summary>
        public static string UserAgent { get; }

        static SdkVersion()
        {
            var assembly = typeof(SdkVersion).Assembly;
            var version = assembly.GetName().Version;

            Version = version != null
            ? $"{version.Major}.{version.Minor}.{version.Build}"
            : "1.0.0";

            UserAgent = $"FacturamaSDK/{version}";
        }
    }
}
