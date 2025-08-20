using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Employees.Dtos;

namespace ArarasHealthHub.Application.Features.Orders.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string? Observation { get; set; }
        public OrderStatusDto? OrderStatus { get; set; }

        public EmployeeNameDto? CreatedByEmployee { get; set; }
        public AccountNameDto? CreatedByAccount { get; set; }
        public EmployeeNameDto? ApprovedByEmployee { get; set; }
        public AccountNameDto? ApprovedByAccount { get; set; }
        public EmployeeNameDto? SeparatedByEmployee { get; set; }
        public AccountNameDto? SeparatedByAccount { get; set; }
        public EmployeeNameDto? FinalizedByEmployee { get; set; }
        public AccountNameDto? FinalizedByAccount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DateTime? SeparatedAt { get; set; }
        public DateTime? FinalizedAt { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
