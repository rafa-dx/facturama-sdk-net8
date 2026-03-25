using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed class  PaginatedResponse<T>
    {
        [JsonPropertyName("data")]
        public required IReadOnlyList<T> Items { get; set; }


        /// <summary>Total de registros sin filtros</summary>
        [JsonPropertyName("recordsTotal")]
        public required int recordsTotal { get; set; }

        /// <summary>Total de registros después de aplicar filtros</summary>
        [JsonPropertyName("recordsFiltered")]
        public required int recordsFiltered { get; set; }

        /// <summary>Índice inicial solicitado</summary>
        //public required int Start { get; set; }

        /// <summary>Cantidad solicitada</summary>
        //public required int Length { get; set; }
    }
}
