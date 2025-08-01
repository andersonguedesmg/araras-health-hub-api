using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }
        public int RequestedQuantity { get; set; }
    }
}
