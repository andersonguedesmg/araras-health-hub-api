using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.ApproveOrder
{
    public record ApproveOrderCommand(
        int OrderId,
        int ApprovedByEmployeeId,
        int ApprovedByAccountId,
        List<ApproveOrderItemDto> OrderItems
    ) : IRequest<ApiResponse<OrderDto>>, ITransactionalRequest;
}
