using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder
{
    public record ApproveOrderCommand(
        int OrderId,
        int ApprovedByEmployeeId,
        List<ApproveOrderItemCommand> Items
    ) : IRequest<Result<int>>, ITransactionalRequest;

    public record ApproveOrderItemCommand(
        int OrderItemId,
        decimal ApprovedQuantity
    );
}
