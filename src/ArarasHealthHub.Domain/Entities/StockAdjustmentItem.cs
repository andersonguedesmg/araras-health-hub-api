using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

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
            int? stockLotId = null,
            string? batch = null,
            string? brand = null,
            DateTime? expiryDate = null)
        {
            if (quantity <= 0)
                throw new DomainException(
                    "Quantidade deve ser maior que zero."
                );

            if (unitValue.HasValue && unitValue < 0)
                throw new DomainException(
                    "Valor unitário inválido."
                );

            ProductId = productId;
            Quantity = quantity;
            UnitValue = unitValue;
            TotalValue = unitValue.HasValue
                ? quantity * unitValue.Value
                : null;

            StockLotId = stockLotId;
            Batch = batch?.Trim();
            Brand = brand?.Trim();
            ExpiryDate = expiryDate;
        }
    }
}
