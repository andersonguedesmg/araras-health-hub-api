using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(
        string? Observation,
        int CreatedByEmployeeId,
        int CreatedByAccountId,
        List<CreateOrderItemDto> OrderItems
    ) : IRequest<ApiResponse<OrderDto>>, ITransactionalRequest;
}
