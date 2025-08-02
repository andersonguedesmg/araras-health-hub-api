using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Application.Interfaces;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Commands.FinalizeOrder
{
    public record FinalizeOrderCommand(
        int OrderId,
        int FinalizedByEmployeeId,
        int FinalizedByAccountId
    ) : IRequest<ApiResponse<OrderDto>>, ITransactionalRequest;
}
