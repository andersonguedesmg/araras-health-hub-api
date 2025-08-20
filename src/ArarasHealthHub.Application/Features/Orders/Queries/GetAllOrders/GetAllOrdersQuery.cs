using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : PagedRequest, IRequest<PagedResponse<OrderDto>>
    {
        public int? OrderStatusId { get; set; }
    }
}
