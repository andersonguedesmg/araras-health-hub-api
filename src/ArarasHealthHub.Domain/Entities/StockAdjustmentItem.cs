using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockAdjustmentItem : BaseEntity
    {
        public int StockAdjustmentId { get; private set; }
        public StockAdjustment StockAdjustment { get; private set; } = null!;

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int? StockLotId { get; private set; }
        public StockLot? StockLot { get; private set; }

        public decimal Quantity { get; private set; }

        public decimal? UnitValue { get; private set; }
        public decimal? TotalValue { get; private set; }

        public string? Batch { get; private set; }
        public string? Brand { get; private set; }
        public DateTime? ExpiryDate { get; private set; }

        private StockAdjustmentItem() { }

        public StockAdjustmentItem(
            int productId,
            decimal quantity,
            decimal? unitValue = null,
            decimal? totalValue = null,
            int? stockLotId = null)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitValue = unitValue;
            TotalValue = totalValue;
            StockLotId = stockLotId;
        }
    }
}
