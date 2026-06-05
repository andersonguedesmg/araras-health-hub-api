using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Return
{
    public interface IOrderReturnService
    {
        Task<Result<int>> CreateAsync(
            CreateReturnOrderCommand command,
            CancellationToken cancellationToken);
    }
}
