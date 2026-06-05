using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Finalization
{
    public interface IOrderFinalizationService
    {
        Task<Result<int>> FinalizeAsync(
            FinalizeOrderCommand command,
            CancellationToken cancellationToken);
    }
}
