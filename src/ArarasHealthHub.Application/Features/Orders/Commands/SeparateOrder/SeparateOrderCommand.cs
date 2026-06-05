using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder
{
    public record SeparateOrderCommand(
        int OrderId,
        int SeparatedByEmployeeId,
        List<SeparateOrderItemCommand> OrderItems
    ) : IRequest<Result<int>>, ITransactionalRequest;

    public record SeparateOrderItemCommand(
        int OrderItemId,
        decimal ActualQuantity
    );
}
