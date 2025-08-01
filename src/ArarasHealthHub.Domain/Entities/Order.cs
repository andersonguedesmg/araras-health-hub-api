using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class Order : BaseEntity
    {
        [MaxLength(200)]
        public string? Observation { get; set; } = string.Empty;

        public List<OrderItem> OrderItems { get; set; } = new();

        [Required]
        public int OrderStatusId { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public int CreatedByEmployeeId { get; set; }

        public Employee? CreatedByEmployee { get; set; }

        [Required]
        public int CreatedByAccountId { get; set; }

        public ApplicationUser? CreatedByAccount { get; set; }


        public DateTime? ApprovedAt { get; set; }

        public int? ApprovedByEmployeeId { get; set; }

        public Employee? ApprovedByEmployee { get; set; }

        public int? ApprovedByAccountId { get; set; }

        public ApplicationUser? ApprovedByAccount { get; set; }


        public DateTime? SeparatedAt { get; set; }

        public int? SeparatedByEmployeeId { get; set; }

        public Employee? SeparatedByEmployee { get; set; }

        public int? SeparatedByAccountId { get; set; }

        public ApplicationUser? SeparatedByAccount { get; set; }


        public DateTime? FinalizedAt { get; set; }

        public int? FinalizedByEmployeeId { get; set; }

        public Employee? FinalizedByEmployee { get; set; }

        public int? FinalizedByAccountId { get; set; }

        public ApplicationUser? FinalizedByAccount { get; set; }
    }
}
