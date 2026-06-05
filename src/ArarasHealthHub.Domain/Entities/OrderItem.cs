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

        public void ReserveQuantity(decimal quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(
                    "Quantidade reservada inválida."
                );
            }

            if (ReservedQuantity + quantity > ApprovedQuantity)
            {
                throw new DomainRuleException(
                    "Reserva excede quantidade aprovada."
                );
            }

            ReservedQuantity += quantity;

            SetUpdatedOn();
        }

        public void ReleaseReservation(decimal quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(
                    "Quantidade inválida."
                );
            }

            if (quantity > ReservedQuantity)
            {
                throw new DomainRuleException(
                    "Liberação excede reserva atual."
                );
            }

            ReservedQuantity -= quantity;

            SetUpdatedOn();
        }

        public void AddLot(OrderItemLot lot)
        {
            ArgumentNullException.ThrowIfNull(lot);

            if (ActualQuantity + lot.Quantity > ApprovedQuantity)
            {
                throw new DomainRuleException(
                    "Separação excede quantidade aprovada."
                );
            }

            _lots.Add(lot);

            ActualQuantity += lot.Quantity;

            SetUpdatedOn();
        }

        public void SeparateQuantity(decimal quantity)
        {
            if (quantity < 0)
            {
                throw new DomainRuleException(
                    "Quantidade separada inválida.");
            }

            if (quantity > ReservedQuantity)
            {
                throw new DomainRuleException(
                    "Quantidade separada não pode exceder a reservada.");
            }

            ActualQuantity = quantity;
        }
    }
}
