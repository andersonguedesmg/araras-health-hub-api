using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderItemLot : BaseEntity
    {
        public int OrderItemId { get; private set; }
        public OrderItem OrderItem { get; private set; } = null!;

        public int StockLotId { get; private set; }
        public StockLot StockLot { get; private set; } = null!;

        public decimal Quantity { get; private set; }

        public decimal UnitValue { get; private set; }

        public decimal TotalValue { get; private set; }

        private OrderItemLot() { }

        public OrderItemLot(
            int stockLotId,
            decimal quantity,
            decimal unitValue)
        {
            if (stockLotId <= 0)
                throw new DomainException("Lote inválido.");

            if (quantity <= 0)
                throw new DomainException(
                    "Quantidade deve ser maior que zero."
                );

            if (unitValue < 0)
                throw new DomainException(
                    "Valor unitário inválido."
                );

            StockLotId = stockLotId;
            Quantity = quantity;
            UnitValue = unitValue;

            TotalValue = decimal.Round(quantity * unitValue, 2, MidpointRounding.ToEven);
        }
    }
}
