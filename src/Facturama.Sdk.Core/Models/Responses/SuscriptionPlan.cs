namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record SuscriptionPlan
    {
        public string Plan { get; init; }
        public string CurrentFolios { get; init; }
        public string CreationDate { get; init; }
        public string ExpirationDate { get; init; }    
    }
}
