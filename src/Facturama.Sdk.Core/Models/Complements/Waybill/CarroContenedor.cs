namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record CarroContenedor
    {
        public string TipoContenedor { get; init; }

        public decimal PesoContenedorVacio { get; init; }

        public decimal PesoNetoMercancia { get; init; }
    }
}
