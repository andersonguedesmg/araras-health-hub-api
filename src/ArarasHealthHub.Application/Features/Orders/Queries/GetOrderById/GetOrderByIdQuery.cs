using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderById
{
    public record GetOrderByIdQuery(int OrderId) : IRequest<ApiResponseO<OrderDto>>;
}
