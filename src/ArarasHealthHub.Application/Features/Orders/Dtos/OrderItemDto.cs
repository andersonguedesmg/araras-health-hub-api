using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal RequestedQuantity { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public decimal ReservedQuantity { get; set; }
        public decimal ActualQuantity { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
