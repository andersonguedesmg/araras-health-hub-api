using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class ReceivedItem : BaseEntity
    {
        public int ReceivingId { get; private set; }
        public Receiving Receiving { get; private set; } = null!;

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public decimal Quantity { get; private set; }

        public decimal UnitValue { get; private set; }

        public decimal TotalValue
            => Quantity * UnitValue;

        public string Batch { get; private set; } = string.Empty;

        public string Brand { get; private set; } = string.Empty;

        public DateTime ExpiryDate { get; private set; }

        private ReceivedItem() { }

        public ReceivedItem(
            int productId,
            decimal quantity,
            decimal unitValue,
            string batch,
            string brand,
            DateTime expiryDate)
        {
            if (quantity <= 0)
                throw new DomainException(
                    "Quantidade deve ser maior que zero.");

            if (unitValue < 0)
                throw new DomainException(
                    "Valor unitário não pode ser negativo.");

            ProductId = productId;
            Quantity = quantity;
            UnitValue = unitValue;
            Batch = batch;
            Brand = brand;
            ExpiryDate = expiryDate;
        }
    }
}
