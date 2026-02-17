namespace Facturama.Sdk.Configuration
{
   {
    /// <summary>
    /// Configuración de la política de reintentos para peticiones HTTP.
    /// </summary>
    public sealed class RetryPolicyConfiguration
    {
        /// <summary>
        /// Número máximo de reintentos antes de fallar definitivamente.
        /// Default: 3.
        /// </summary>
        public int MaxRetries { get; set; } = 3;

        /// <summary>
        /// Delay inicial antes del primer reintento.
        /// Default: 1 segundo.
        /// </summary>
        public TimeSpan InitialDelay { get; set; } = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Delay máximo permitido entre reintentos.
        /// Default: 30 segundos.
        /// </summary>
        public TimeSpan MaxDelay { get; set; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Tipo de estrategia de backoff para calcular delays entre reintentos.
        /// Default: Exponential.
        /// </summary>
        public BackoffType BackoffType { get; set; } = BackoffType.Exponential;

        /// <summary>
        /// Multiplicador para backoff exponencial o lineal.
        /// Default: 2.0 (duplica el delay en cada intento).
        /// </summary>
        public double BackoffMultiplier { get; set; } = 2.0;

        /// <summary>
        /// Códigos de estado HTTP que deben reintentarse.
        /// Default: 408 (Request Timeout), 429 (Too Many Requests), 500, 502, 503, 504.
        /// </summary>
        public List<int> RetryOnStatusCodes { get; set; } = new()
    {
        408,  // Request Timeout
        429,  // Too Many Requests
        500,  // Internal Server Error
        502,  // Bad Gateway
        503,  // Service Unavailable
        504   // Gateway Timeout
    };

        /// <summary>
        /// Habilita jitter (variación aleatoria) en los delays para evitar thundering herd.
        /// Default: true.
        /// </summary>
        public bool EnableJitter { get; set; } = true;

        /// <summary>
        /// Calcula el delay para un intento específico según la configuración.
        /// </summary>
        /// <param name="retryAttempt">Número del intento (1, 2, 3...).</param>
        /// <returns>TimeSpan del delay a aplicar.</returns>
        public TimeSpan CalculateDelay(int retryAttempt)
        {
            if (retryAttempt < 1)
            {
                return TimeSpan.Zero;
            }

            TimeSpan delay = BackoffType switch
            {
                BackoffType.Constant => InitialDelay,
                BackoffType.Linear => TimeSpan.FromMilliseconds(
                    InitialDelay.TotalMilliseconds * retryAttempt),
                BackoffType.Exponential => TimeSpan.FromMilliseconds(
                    InitialDelay.TotalMilliseconds * Math.Pow(BackoffMultiplier, retryAttempt - 1)),
                _ => InitialDelay
            };

            // Aplicar límite máximo
            if (delay > MaxDelay)
            {
                delay = MaxDelay;
            }

            // Aplicar jitter (variación aleatoria ±25%)
            if (EnableJitter)
            {
                var jitterFactor = Random.Shared.NextDouble() * 0.5 + 0.75; // 0.75 a 1.25
                delay = TimeSpan.FromMilliseconds(delay.TotalMilliseconds * jitterFactor);
            }

            return delay;
        }

        /// <summary>
        /// Valida que la configuración sea correcta.
        /// </summary>
        public void Validate()
        {
            if (MaxRetries < 0)
            {
                throw new ArgumentException(
                    "MaxRetries no puede ser negativo.",
                    nameof(MaxRetries));
            }

            if (MaxRetries > 10)
            {
                throw new ArgumentException(
                    "MaxRetries no puede ser mayor a 10.",
                    nameof(MaxRetries));
            }

            if (InitialDelay <= TimeSpan.Zero)
            {
                throw new ArgumentException(
                    "InitialDelay debe ser mayor a cero.",
                    nameof(InitialDelay));
            }

            if (MaxDelay < InitialDelay)
            {
                throw new ArgumentException(
                    "MaxDelay no puede ser menor que InitialDelay.",
                    nameof(MaxDelay));
            }

            if (BackoffMultiplier < 1.0)
            {
                throw new ArgumentException(
                    "BackoffMultiplier debe ser al menos 1.0.",
                    nameof(BackoffMultiplier));
            }

            if (RetryOnStatusCodes == null || !RetryOnStatusCodes.Any())
            {
                throw new ArgumentException(
                    "RetryOnStatusCodes debe tener al menos un código de estado.",
                    nameof(RetryOnStatusCodes));
            }

            if (RetryOnStatusCodes.Any(code => code < 100 || code > 599))
            {
                throw new ArgumentException(
                    "Todos los códigos en RetryOnStatusCodes deben estar entre 100 y 599.",
                    nameof(RetryOnStatusCodes));
            }
        }
    }

    /// <summary>
    /// Tipo de estrategia de backoff para calcular delays entre reintentos.
    /// </summary>
    public enum BackoffType
    {
        /// <summary>
        /// Delay constante: Siempre espera el mismo tiempo.
        /// Ejemplo: 1s, 1s, 1s
        /// </summary>
        Constant = 0,

        /// <summary>
        /// Backoff lineal: Incremento proporcional al número de intento.
        /// Ejemplo: 1s, 2s, 3s, 4s
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Backoff exponencial: Incremento exponencial.
        /// Ejemplo con multiplicador 2: 1s, 2s, 4s, 8s, 16s
        /// Recomendado para la mayoría de casos.
        /// </summary>
        Exponential = 2
    }
}
}