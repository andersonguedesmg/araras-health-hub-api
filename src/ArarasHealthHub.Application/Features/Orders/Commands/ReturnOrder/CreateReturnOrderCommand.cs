using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ReturnOrder
{
    public record CreateReturnOrderCommand(
        int OriginalOrderId,
        string Reason,
        int ReturnedByEmployeeId,
        List<CreateReturnOrderItemCommand> Items
    ) : IRequest<Result<int>>, ITransactionalRequest;

    public record CreateReturnOrderItemCommand(
        int ProductId,
        decimal Quantity
    );
}
