using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

        protected StockLot() { }

        public StockLot(
            int stockId,
            string batch,
            string brand,
            decimal unitValue,
            DateTime expiryDate,
            decimal quantity)
        {
            StockId = stockId;
            Batch = batch;
            Brand = brand;
            UnitValue = unitValue;
            ExpiryDate = expiryDate;
            AvailableQuantity = quantity;
        }

        public void AddQuantity(decimal quantity)
        {
            if (quantity <= 0) return;
            AvailableQuantity += quantity;
            SetUpdatedOn();
        }

        public void RemoveQuantity(decimal quantity)
        {
            if (quantity <= 0) return;
            if (AvailableQuantity < quantity)
                throw new ApplicationException(
                    $"Baixa de {quantity} excede a quantidade disponível ({AvailableQuantity}) no lote {Batch}");

            AvailableQuantity -= quantity;
            SetUpdatedOn();
        }
    }
}
