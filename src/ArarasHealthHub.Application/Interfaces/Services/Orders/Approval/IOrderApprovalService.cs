using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder;
using ArarasHealthHub.Shared.Results;

namespace ArarasHealthHub.Application.Interfaces.Services.Orders.Approval
{
    public interface IOrderApprovalService
    {
        Task<Result<int>> ApproveOrderAsync(
            ApproveOrderCommand command,
            CancellationToken cancellationToken);
    }
}
