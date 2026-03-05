using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal RequestedQuantity { get; private set; }
        public decimal ApprovedQuantity { get; private set; }
        public decimal ReservedQuantity { get; private set; }
        public decimal ActualQuantity { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int OrderId { get; private set; }
        public Order Order { get; private set; } = null!;

        private readonly List<OrderItemLot> _lots = new();
        public IReadOnlyCollection<OrderItemLot> OrderItemLots => _lots;

        private OrderItem() { }

        public OrderItem(int productId, decimal requestedQuantity)
        {
            ProductId = productId;
            RequestedQuantity = requestedQuantity;
        }

        public void AddLot(OrderItemLot lot)
        {
            _lots.Add(lot);
        }
    }
}
