using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string Observation { get; set; } = string.Empty;

        public List<OrderItem> OrderItems { get; set; } = new();

        public int OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedByEmployeeId { get; set; }
        public Employee? CreatedByEmployee { get; set; }
        public int CreatedByAccountId { get; set; }
        public AppUser? CreatedByAccount { get; set; }

        public DateTime? ApprovedAt { get; set; }
        public int? ApprovedByEmployeeId { get; set; }
        public Employee? ApprovedByEmployee { get; set; }
        public int? ApprovedByAccountId { get; set; }
        public AppUser? ApprovedByAccount { get; set; }

        public DateTime? SeparatedAt { get; set; }
        public int? SeparatedByEmployeeId { get; set; }
        public Employee? SeparatedByEmployee { get; set; }
        public int? SeparatedByAccountId { get; set; }
        public AppUser? SeparatedByAccount { get; set; }

        public DateTime? FinalizedAt { get; set; }
        public int? FinalizedByEmployeeId { get; set; }
        public Employee? FinalizedByEmployee { get; set; }
        public int? FinalizedByAccountId { get; set; }
        public AppUser? FinalizedByAccount { get; set; }
    }
}
