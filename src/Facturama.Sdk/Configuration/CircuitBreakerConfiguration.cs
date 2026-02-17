namespace Facturama.Sdk.Configuration
{
    public sealed class CircuitBreakerConfiguration
    {
        /// <summary>
        /// Número de fallos consecutivos antes de abrir el circuito.
        /// Default: 5.
        /// </summary>
        public int FailuresBeforeBreaking { get; set; } = 5;

        /// <summary>
        /// Duración en la que el circuito permanece abierto antes de permitir reintentos.
        /// Default: 30 segundos.
        /// </summary>
        public TimeSpan DurationOfBreak { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Habilita o deshabilita el Circuit Breaker completamente.
        /// Default: true.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Ventana de tiempo para evaluar fallos (opcional).
        /// Si se especifica, evalúa fallos dentro de esta ventana de tiempo
        /// en lugar de consecutivos.
        /// Default: null (usa fallos consecutivos).
        /// </summary>
        public TimeSpan? SamplingDuration { get; set; }

        /// <summary>
        /// Porcentaje mínimo de fallos requerido para abrir el circuito
        /// cuando se usa SamplingDuration.
        /// Default: 50% (0.5).
        /// </summary>
        public double MinimumThroughput { get; set; } = 0.5;

        /// <summary>
        /// Valida que la configuración sea correcta.
        /// </summary>
        public void Validate()
        {
            if (FailuresBeforeBreaking < 1)
            {
                throw new ArgumentException(
                    "FailuresBeforeBreaking debe ser al menos 1.",
                    nameof(FailuresBeforeBreaking));
            }

            if (FailuresBeforeBreaking > 100)
            {
                throw new ArgumentException(
                    "FailuresBeforeBreaking no puede ser mayor a 100.",
                    nameof(FailuresBeforeBreaking));
            }

            if (DurationOfBreak <= TimeSpan.Zero)
            {
                throw new ArgumentException(
                    "DurationOfBreak debe ser mayor a cero.",
                    nameof(DurationOfBreak));
            }

            if (DurationOfBreak > TimeSpan.FromMinutes(10))
            {
                throw new ArgumentException(
                    "DurationOfBreak no puede ser mayor a 10 minutos.",
                    nameof(DurationOfBreak));
            }

            if (SamplingDuration.HasValue)
            {
                if (SamplingDuration.Value <= TimeSpan.Zero)
                {
                    throw new ArgumentException(
                        "SamplingDuration debe ser mayor a cero si se especifica.",
                        nameof(SamplingDuration));
                }

                if (MinimumThroughput < 0.0 || MinimumThroughput > 1.0)
                {
                    throw new ArgumentException(
                        "MinimumThroughput debe estar entre 0.0 y 1.0.",
                        nameof(MinimumThroughput));
                }
            }
        }
    }
}
