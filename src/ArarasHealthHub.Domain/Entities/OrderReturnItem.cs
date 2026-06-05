using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderReturnItem : BaseEntity
    {
        public int OrderReturnId { get; private set; }
        public OrderReturn OrderReturn { get; private set; } = null!;

        public int ProductId { get; private set; }
        public Product Product { get; private set; } = null!;

        public int StockLotId { get; private set; }
        public StockLot StockLot { get; private set; } = null!;

        public decimal Quantity { get; private set; }

        public decimal UnitValue { get; private set; }

        public decimal TotalValue { get; private set; }

        private OrderReturnItem() { }

        public OrderReturnItem(
            int productId,
            int stockLotId,
            decimal quantity,
            decimal unitValue)
        {
            if (productId <= 0)
            {
                throw new DomainException("Produto inválido.");
            }

            if (stockLotId <= 0)
            {
                throw new DomainException("Lote inválido.");
            }

            if (quantity <= 0)
            {
                throw new DomainException("Quantidade deve ser maior que zero.");
            }

            if (unitValue <= 0)
            {
                throw new DomainException("Valor unitário deve ser maior que zero.");
            }

            ProductId = productId;
            StockLotId = stockLotId;

            Quantity = quantity;
            UnitValue = unitValue;

            TotalValue = quantity * unitValue;
        }
    }
}
