using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetOrderPickingDetails
{
    public class GetOrderPickingDetailsQuery : IRequest<ApiResponse<OrderDto>>
    {
        public int Id { get; set; }
    }
}
