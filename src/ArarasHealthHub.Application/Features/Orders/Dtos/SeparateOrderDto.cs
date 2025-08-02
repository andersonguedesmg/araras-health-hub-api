using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class SeparateOrderDto
    {
        public int OrderId { get; set; }
        public int SeparatedByEmployeeId { get; set; }
        public int SeparatedByAccountId { get; set; }
        public List<SeparateOrderItemDto> OrderItems { get; set; } = new();
    }
}
