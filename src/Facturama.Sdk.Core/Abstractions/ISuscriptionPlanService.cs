using Facturama.Sdk.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturama.Sdk.Core.Abstractions
{
    public interface ISuscriptionPlanService
    {
        //Read
        Task<SuscriptionPlanResponse> GetAsync(
            CancellationToken cancellationToken = default);
    }
}
