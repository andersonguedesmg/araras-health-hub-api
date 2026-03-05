using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public decimal CurrentQuantity { get; private set; }
        public decimal ReservedQuantity { get; private set; }
        public decimal AvailableQuantity { get; private set; }
        public decimal MinQuantity { get; private set; }

        public StockCost? StockCost { get; private set; }

        private readonly List<StockLot> _lots = new();
        public IReadOnlyCollection<StockLot> Lots => _lots;

        protected Stock() { }

        public Stock(int productId, decimal minQuantity)
        {
            ProductId = productId;
            MinQuantity = minQuantity;
            CurrentQuantity = 0;
            ReservedQuantity = 0;
            AvailableQuantity = 0;
        }

        public void UpdateQuantities(decimal current, decimal reserved)
        {
            CurrentQuantity = current;
            ReservedQuantity = reserved;
            AvailableQuantity = current - reserved;
            SetUpdatedOn();
        }
    }
}
