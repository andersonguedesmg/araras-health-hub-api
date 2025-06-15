using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Order
{
    public class CreateOrderDto
    {
        public int CreatedByEmployeeId { get; set; }

        public int CreatedByAccountId { get; set; }

        public string? Observation { get; set; }

        public int OrderStatusId { get; set; }

        public List<CreateOrderItemDto> OrderItems { get; set; } = new();
    }
}
