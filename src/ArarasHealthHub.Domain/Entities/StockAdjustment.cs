using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockAdjustment : BaseEntity
    {
        private readonly List<StockAdjustmentItem> _items = [];

        public StockAdjustmentType Type { get; private set; }

        public string Reason { get; private set; } = string.Empty;

        public string? Observation { get; private set; }

        public DateTime AdjustmentDate { get; private set; }

        public int ResponsibleId { get; private set; }
        public Employee Responsible { get; private set; } = null!;

        public int AccountId { get; private set; }
        public ApplicationUser Account { get; private set; } = null!;

        public IReadOnlyCollection<StockAdjustmentItem> Items => _items;

        private StockAdjustment() { }

        public StockAdjustment(
            StockAdjustmentType type,
            string reason,
            DateTime adjustmentDate,
            int responsibleId,
            int accountId,
            string? observation = null)
        {
            Validate(reason, adjustmentDate);

            Type = type;
            Reason = reason.Trim();
            AdjustmentDate = adjustmentDate;
            ResponsibleId = responsibleId;
            AccountId = accountId;
            Observation = observation?.Trim();
        }

        public void AddItem(StockAdjustmentItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            _items.Add(item);

            SetUpdatedOn();
        }

        public void UpdateObservation(string? observation)
        {
            Observation = observation?.Trim();

            SetUpdatedOn();
        }

        private static void Validate(
            string reason,
            DateTime adjustmentDate)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new DomainException(
                    "Motivo do ajuste é obrigatório."
                );

            if (adjustmentDate == default)
                throw new DomainException(
                    "Data do ajuste inválida."
                );
        }
    }
}
