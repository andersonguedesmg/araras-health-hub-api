using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockLot : BaseEntity
    {
        public int StockId { get; private set; }

        public Stock Stock { get; private set; } = null!;

        public string Batch { get; private set; } = string.Empty;

        public string Brand { get; private set; } = string.Empty;

        public decimal UnitValue { get; private set; }

        public DateTime ExpiryDate { get; private set; }

        public decimal AvailableQuantity { get; private set; }

        public int? ReceivedItemId { get; private set; }

        public ReceivedItem? ReceivedItem { get; private set; }

        private StockLot() { }

        public StockLot(
            int stockId,
            string batch,
            string brand,
            decimal unitValue,
            DateTime expiryDate,
            decimal quantity,
            int? receivedItemId = null)
        {
            if (stockId <= 0)
                throw new DomainException("Estoque inválido.");

            if (string.IsNullOrWhiteSpace(batch))
                throw new DomainException("Lote é obrigatório.");

            if (unitValue < 0)
                throw new DomainException(
                    "Valor unitário inválido."
                );

            if (quantity <= 0)
                throw new DomainException(
                    "Quantidade deve ser maior que zero."
                );

            StockId = stockId;
            Batch = batch.Trim();
            Brand = brand.Trim();
            UnitValue = unitValue;
            ExpiryDate = expiryDate;
            AvailableQuantity = quantity;
            ReceivedItemId = receivedItemId;
        }

        public void IncreaseQuantity(decimal quantity)
        {
            ValidatePositiveQuantity(quantity);

            AvailableQuantity += quantity;

            SetUpdatedOn();
        }

        public void DecreaseQuantity(decimal quantity)
        {
            ValidatePositiveQuantity(quantity);

            if (AvailableQuantity < quantity)
            {
                throw new DomainRuleException(
                    $"Saldo insuficiente no lote {Batch}."
                );
            }

            AvailableQuantity -= quantity;

            SetUpdatedOn();
        }

        private static void ValidatePositiveQuantity(decimal quantity)
        {
            if (quantity <= 0)
            {
                throw new DomainException(
                    "Quantidade deve ser maior que zero."
                );
            }
        }
    }
}
