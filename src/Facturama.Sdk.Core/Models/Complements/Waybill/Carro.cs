namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record Carro
    {
        public string TipoCarro { get; init; }

        public string MatriculaCarro { get; init; }

        public string GuiaCarro { get; init; }

        public decimal ToneladasNetasCarro { get; init; }

        public CarroContenedor[] Contenedor { get; init; }
    }
}
