using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class DispenseReturnItem : BaseEntity
    {
        public int DispenseReturnId { get; private set; }
        public DispenseReturn DispenseReturn { get; private set; } = null!;

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int StockLotId { get; private set; }
        public StockLot StockLot { get; private set; } = null!;

        public decimal Quantity { get; private set; }
        public decimal UnitValue { get; private set; }
        public decimal TotalValue { get; private set; }

        public string Batch { get; private set; } = string.Empty;
        public string Brand { get; private set; } = string.Empty;
        public DateTime ExpiryDate { get; private set; }

        private DispenseReturnItem() { }

        public DispenseReturnItem(
            int productId,
            int stockLotId,
            decimal quantity,
            decimal unitValue,
            string batch,
            string brand,
            DateTime expiryDate)
        {
            ProductId = productId;
            StockLotId = stockLotId;
            Quantity = quantity;
            UnitValue = unitValue;
            TotalValue = quantity * unitValue;
            Batch = batch;
            Brand = brand;
            ExpiryDate = expiryDate;
        }
    }
}
