using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Observation { get; set; }
        public int OrderStatusId { get; set; }
        public int CreatedByEmployeeId { get; set; }
        public int CreatedByAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? SeparatedAt { get; set; }
        public DateTime? FinalizedAt { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
