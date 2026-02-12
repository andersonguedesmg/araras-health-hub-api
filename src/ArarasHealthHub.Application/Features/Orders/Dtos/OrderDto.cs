using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Core.Dtos;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Observation { get; set; }
        public OrderStatusDto? OrderStatus { get; set; }
        public DropdownItemDto? OrderFacility { get; set; }

        public DropdownItemDto? CreatedByEmployee { get; set; }
        public AccountMinimalDto? CreatedByAccount { get; set; }
        public DropdownItemDto? ApprovedByEmployee { get; set; }
        public AccountMinimalDto? ApprovedByAccount { get; set; }
        public DropdownItemDto? SeparatedByEmployee { get; set; }
        public AccountMinimalDto? SeparatedByAccount { get; set; }
        public DropdownItemDto? FinalizedByEmployee { get; set; }
        public AccountMinimalDto? FinalizedByAccount { get; set; }
        public DropdownItemDto? CanceledByEmployee { get; set; }
        public AccountMinimalDto? CanceledByAccount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? SeparatedAt { get; set; }
        public DateTime? FinalizedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
