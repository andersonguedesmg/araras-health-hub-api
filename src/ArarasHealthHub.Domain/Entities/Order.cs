using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string? Observation { get; private set; }

        public int OrderFacilityId { get; private set; }
        public Facility OrderFacility { get; private set; } = null!;

        public int OrderStatusId { get; private set; }
        public OrderStatus OrderStatus { get; private set; } = null!;

        public DateTime CreatedAt { get; private set; }

        public int CreatedByEmployeeId { get; private set; }
        public Employee CreatedByEmployee { get; private set; } = null!;

        public int CreatedByAccountId { get; private set; }
        public ApplicationUser CreatedByAccount { get; private set; } = null!;

        public DateTime? ApprovedAt { get; private set; }
        public int? ApprovedByEmployeeId { get; private set; }
        public int? ApprovedByAccountId { get; private set; }

        public DateTime? SeparatedAt { get; private set; }
        public int? SeparatedByEmployeeId { get; private set; }
        public int? SeparatedByAccountId { get; private set; }

        public DateTime? FinalizedAt { get; private set; }
        public int? FinalizedByEmployeeId { get; private set; }
        public int? FinalizedByAccountId { get; private set; }

        public DateTime? CanceledAt { get; private set; }
        public int? CanceledByEmployeeId { get; private set; }
        public int? CanceledByAccountId { get; private set; }

        public string? CancellationReason { get; private set; }

        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> OrderItems => _items;

        private Order() { }

        public Order(
            int facilityId,
            int statusId,
            int employeeId,
            int accountId,
            string? observation = null)
        {
            OrderFacilityId = facilityId;
            OrderStatusId = statusId;
            CreatedByEmployeeId = employeeId;
            CreatedByAccountId = accountId;
            Observation = observation;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
