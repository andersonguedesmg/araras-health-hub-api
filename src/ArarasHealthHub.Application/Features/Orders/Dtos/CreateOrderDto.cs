using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Orders.Dtos;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class CreateOrderDto
    {
        public int CreatedByEmployeeId { get; set; }
        public int CreatedByAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Observation { get; set; } = string.Empty;
        public List<CreateOrderItemDto> OrderItems { get; set; } = new();
    }
}
