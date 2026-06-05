using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Orders.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : PagedRequest, IRequest<PagedResult<OrderListItemResponse>>
    {
        public int? OrderStatusId { get; set; }
    }
}
