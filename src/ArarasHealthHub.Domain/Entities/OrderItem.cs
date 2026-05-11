using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        private readonly List<OrderItemLot> _lots = [];

        public decimal RequestedQuantity { get; private set; }

        public decimal ApprovedQuantity { get; private set; }

        public decimal ReservedQuantity { get; private set; }

        public decimal ActualQuantity { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int OrderId { get; private set; }
        public Order Order { get; private set; } = null!;

        public IReadOnlyCollection<OrderItemLot> OrderItemLots => _lots;

        private OrderItem() { }

        public OrderItem(
            int productId,
            decimal requestedQuantity)
        {
            if (productId <= 0)
                throw new DomainException("Produto inválido.");

            if (requestedQuantity <= 0)
                throw new DomainException(
                    "Quantidade solicitada deve ser maior que zero."
                );

            ProductId = productId;
            RequestedQuantity = requestedQuantity;
        }

        public void ApproveQuantity(decimal quantity)
        {
            if (quantity <= 0)
                throw new DomainException(
                    "Quantidade aprovada inválida."
                );

            if (quantity > RequestedQuantity)
                throw new DomainRuleException(
                    "Quantidade aprovada não pode exceder a solicitada."
                );

            ApprovedQuantity = quantity;

            SetUpdatedOn();
        }

        public void AddLot(OrderItemLot lot)
        {
            ArgumentNullException.ThrowIfNull(lot);

            _lots.Add(lot);

            ReservedQuantity += lot.Quantity;
            ActualQuantity += lot.Quantity;

            SetUpdatedOn();
        }
    }
}
