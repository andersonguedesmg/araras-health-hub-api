using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Results;

using MediatR;
namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(
        string? Observation,
        int CreatedByEmployeeId,
        List<CreateOrderItemCommand> Items
    ) : IRequest<Result<int>>, ITransactionalRequest;

    public record CreateOrderItemCommand(
        int ProductId,
        decimal RequestedQuantity
    );
}
