using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Shared.Responses;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Observation { get; set; }
        public OrderStatusDto? OrderStatus { get; set; }
        public DropdownItemResponse? OrderFacility { get; set; }

        public DropdownItemResponse? CreatedByEmployee { get; set; }
        public AccountMinimalDto? CreatedByAccount { get; set; }
        public DropdownItemResponse? ApprovedByEmployee { get; set; }
        public AccountMinimalDto? ApprovedByAccount { get; set; }
        public DropdownItemResponse? SeparatedByEmployee { get; set; }
        public AccountMinimalDto? SeparatedByAccount { get; set; }
        public DropdownItemResponse? FinalizedByEmployee { get; set; }
        public AccountMinimalDto? FinalizedByAccount { get; set; }
        public DropdownItemResponse? CanceledByEmployee { get; set; }
        public AccountMinimalDto? CanceledByAccount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? SeparatedAt { get; set; }
        public DateTime? FinalizedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
