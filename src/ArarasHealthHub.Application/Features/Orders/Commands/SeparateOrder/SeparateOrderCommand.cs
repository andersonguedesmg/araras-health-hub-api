using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.SeparateOrder
{
    public record SeparateOrderCommand(
        int OrderId,
        int SeparatedByEmployeeId,
        int SeparatedByAccountId,
        List<SeparateOrderItemDto> OrderItems
    ) : IRequest<ApiResponse<OrderDto>>, ITransactionalRequest;
}
