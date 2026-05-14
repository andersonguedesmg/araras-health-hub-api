using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;

namespace ArarasHealthHub.Domain.Entities
{
    public class Stock : BaseEntity
    {
        private readonly List<StockLot> _lots = [];

        public int ProductId { get; private set; }

        public Product Product { get; private set; } = null!;

        public decimal CurrentQuantity { get; private set; }

        public decimal ReservedQuantity { get; private set; }

        public decimal AvailableQuantity
            => CurrentQuantity - ReservedQuantity;

        public decimal MinQuantity { get; private set; }

        public StockCost? StockCost { get; private set; }

        public IReadOnlyCollection<StockLot> Lots
            => _lots.AsReadOnly();

        private Stock() { }

        public Stock(int productId, decimal minQuantity = 0)
        {
            if (productId <= 0)
                throw new DomainException("Produto inválido.");

            if (minQuantity < 0)
                throw new DomainException(
                    "Quantidade mínima não pode ser negativa."
                );

            ProductId = productId;
            MinQuantity = minQuantity;
        }

        public void InitializeCost(
            decimal averageUnitCost,
            decimal currentTotalCost)
        {
            if (StockCost is not null)
            {
                throw new DomainRuleException(
                    "O custo do estoque já foi inicializado."
                );
            }

            StockCost = new StockCost(
                stockId: Id,
                averageUnitCost: averageUnitCost,
                currentTotalCost: currentTotalCost);
        }

        public void IncreaseStock(decimal quantity)
        {
            ValidatePositiveQuantity(quantity);

            CurrentQuantity += quantity;

            SetUpdatedOn();
        }

        public void DecreaseStock(decimal quantity)
        {
            ValidatePositiveQuantity(quantity);

            if (AvailableQuantity < quantity)
            {
                throw new DomainRuleException(
                    $"Saldo insuficiente. Disponível: {AvailableQuantity}."
                );
            }

            CurrentQuantity -= quantity;

            SetUpdatedOn();
        }

        public void Reserve(decimal quantity)
        {
            ValidatePositiveQuantity(quantity);

            if (AvailableQuantity < quantity)
            {
                throw new DomainRuleException(
                    $"Saldo insuficiente para reserva. Disponível: {AvailableQuantity}."
                );
            }

            ReservedQuantity += quantity;

            SetUpdatedOn();
        }

        public void ReleaseReservation(decimal quantity)
        {
            ValidatePositiveQuantity(quantity);

            if (ReservedQuantity < quantity)
            {
                throw new DomainRuleException(
                    "Quantidade reservada insuficiente."
                );
            }

            ReservedQuantity -= quantity;

            SetUpdatedOn();
        }

        public void UpdateMinQuantity(decimal minQuantity)
        {
            if (minQuantity < 0)
            {
                throw new DomainException(
                    "Quantidade mínima não pode ser negativa."
                );
            }

            MinQuantity = minQuantity;

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
