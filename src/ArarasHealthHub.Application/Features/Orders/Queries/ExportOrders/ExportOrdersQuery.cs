using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Orders.Queries.ExportOrders
{
    public class ExportOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
        public int? OrderStatusId { get; set; }
        public string? SearchTerm { get; set; }
    }
}
