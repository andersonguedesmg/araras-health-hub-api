using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Employee.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Order.Dtos
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public string Observation { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public int CreatedByEmployeeId { get; set; }
        public EmployeeDto? CreatedByEmployee { get; set; }
        public int CreatedByAccountId { get; set; }
        // public AppUser? CreatedByAccount { get; set; }

        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        public DateTime? ApprovedAt { get; set; }
        public int? ApprovedByEmployeeId { get; set; }
        public EmployeeDto? ApprovedByEmployee { get; set; }
        public int? ApprovedByAccountId { get; set; }
        // public AppUser? ApprovedByAccount { get; set; }

        public DateTime? SeparatedAt { get; set; }
        public int? SeparatedByEmployeeId { get; set; }
        public EmployeeDto? SeparatedByEmployee { get; set; }
        public int? SeparatedByAccountId { get; set; }
        // public AppUser? SeparatedByAccount { get; set; }

        public DateTime? FinalizedAt { get; set; }
        public int? FinalizedByEmployeeId { get; set; }
        public EmployeeDto? FinalizedByEmployee { get; set; }
        public int? FinalizedByAccountId { get; set; }
        // public AppUser? FinalizedByAccount { get; set; }

        public List<OrderItemResponseDto> OrderItems { get; set; } = new();
    }
}
