using System.Text.Json.Serialization;


namespace Facturama.Sdk.Core.Models.Common
{
    public sealed class  PaginatedResponse<T>
    {
        [JsonPropertyName("data")]
        public required IReadOnlyList<T> Items { get; set; }


        /// <summary>Total de registros sin filtros</summary>
        [JsonPropertyName("classsTotal")]
        public required int Totalclasss { get; set; }

        /// <summary>Total de registros después de aplicar filtros</summary>
        [JsonPropertyName("classsFiltered")]
        public required int Filteredclasss { get; set; }

        /// <summary>Índice inicial solicitado</summary>
        //public required int Start { get; set; }

        /// <summary>Cantidad solicitada</summary>
        //public required int Length { get; set; }
    }
}
