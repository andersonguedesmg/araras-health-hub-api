using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class DispenseReturn : BaseEntity
    {
        private readonly List<DispenseReturnItem> _items = [];

        public int OriginalOrderId { get; private set; }
        public Order OriginalOrder { get; private set; } = null!;

        public string Reason { get; private set; } = string.Empty;

        public DateTime ReturnDate { get; private set; }

        public int ReturnedByEmployeeId { get; private set; }
        public Employee ReturnedByEmployee { get; private set; } = null!;

        public int ReturnedByAccountId { get; private set; }
        public ApplicationUser ReturnedByAccount { get; private set; } = null!;

        public decimal TotalReturnedValue { get; private set; }

        public IReadOnlyCollection<DispenseReturnItem> Items => _items;

        private DispenseReturn() { }

        public DispenseReturn(
            int originalOrderId,
            string reason,
            int returnedByEmployeeId,
            int returnedByAccountId)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new DomainException(
                    "Motivo da devolução é obrigatório."
                );

            OriginalOrderId = originalOrderId;
            Reason = reason.Trim();
            ReturnedByEmployeeId = returnedByEmployeeId;
            ReturnedByAccountId = returnedByAccountId;
            ReturnDate = DateTime.UtcNow;
        }

        public void AddItem(DispenseReturnItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            _items.Add(item);

            RecalculateTotal();

            SetUpdatedOn();
        }

        private void RecalculateTotal()
        {
            TotalReturnedValue = _items.Sum(x => x.TotalValue);
        }
    }
}
