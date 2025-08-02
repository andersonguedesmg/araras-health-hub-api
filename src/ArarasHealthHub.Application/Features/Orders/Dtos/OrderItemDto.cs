using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int RequestedQuantity { get; set; }
        public int ApprovedQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public int ProductId { get; set; }
    }
}
