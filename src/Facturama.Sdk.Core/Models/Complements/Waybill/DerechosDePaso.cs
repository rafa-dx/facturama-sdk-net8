namespace Facturama.Sdk.Core.Models.Complements.Waybill
{
    public sealed record DerechosDePaso
    {
        public string TipoDerechoDePaso { get; init; }

        public string KilometrajePagado { get; init; }
    }
}
