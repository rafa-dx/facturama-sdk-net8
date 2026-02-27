using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Models.Responses
{
    public sealed record SuscriptionPlanResponse
    {
        string Plan { get; init; }
        string CurrentFolios { get; init; }
        string CreationDate { get; init; }
        string ExpirationDate { get; init; }    
    }
}
