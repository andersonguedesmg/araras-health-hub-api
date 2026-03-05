using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class ReceivedItem : BaseEntity
    {
        public decimal Quantity { get; private set; }

        public decimal UnitValue { get; private set; }

        public decimal TotalValue { get; private set; }

        public string Batch { get; private set; } = string.Empty;

        public string Brand { get; private set; } = string.Empty;

        public DateTime ExpiryDate { get; private set; }

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int ReceivingId { get; private set; }
        public Receiving Receiving { get; private set; } = null!;

        private ReceivedItem() { }

        public ReceivedItem(
            int productId,
            decimal quantity,
            decimal unitValue,
            decimal totalValue,
            string batch,
            string brand,
            DateTime expiryDate)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitValue = unitValue;
            TotalValue = totalValue;
            Batch = batch;
            Brand = brand;
            ExpiryDate = expiryDate;
        }
    }
}
