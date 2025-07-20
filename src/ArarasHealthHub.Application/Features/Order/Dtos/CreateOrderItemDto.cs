using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Order.Dtos
{
    public class CreateOrderItemDto
    {
        public int ProductId { get; set; }

        public int RequestedQuantity { get; set; }

        public int ApprovedQuantity { get; set; }

        public int ActualQuantity { get; set; }

        public int OrderId { get; set; }
    }
}
