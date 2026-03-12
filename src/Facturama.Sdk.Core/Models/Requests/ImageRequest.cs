namespace Facturama.Sdk.Core.Models.Request
{
    public sealed record ImageRequest
    {

        public string Img { get; init; }
        public string Type { get; init; }
    }
}
