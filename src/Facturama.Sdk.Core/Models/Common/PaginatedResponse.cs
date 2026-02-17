using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Common
{
    public sealed record  PaginatedResponse<T>
    {
        [JsonPropertyName("data")]
        public required IReadOnlyList<T> Items { get; init; }


        /// <summary>Total de registros sin filtros</summary>
        [JsonPropertyName("recordsTotal")]
        public required int TotalRecords { get; init; }

        /// <summary>Total de registros después de aplicar filtros</summary>
        [JsonPropertyName("recordsFiltered")]
        public required int FilteredRecords { get; init; }

        /// <summary>Índice inicial solicitado</summary>
        //public required int Start { get; init; }

        /// <summary>Cantidad solicitada</summary>
        //public required int Length { get; init; }
    }
}
