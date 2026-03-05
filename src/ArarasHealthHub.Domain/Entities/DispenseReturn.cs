using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class DispenseReturn : BaseEntity
    {
        public int OriginalOrderId { get; private set; }
        public Order OriginalOrder { get; private set; } = null!;

        public string Reason { get; private set; } = string.Empty;
        public DateTime ReturnDate { get; private set; }

        public int ReturnedByEmployeeId { get; private set; }
        public int ReturnedByAccountId { get; private set; }

        public decimal TotalReturnedValue { get; private set; }

        private readonly List<DispenseReturnItem> _items = new();
        public IReadOnlyCollection<DispenseReturnItem> ReturnItems => _items;

        private DispenseReturn() { }

        public DispenseReturn(
            int orderId,
            string reason,
            int employeeId,
            int accountId)
        {
            OriginalOrderId = orderId;
            Reason = reason;
            ReturnedByEmployeeId = employeeId;
            ReturnedByAccountId = accountId;
            ReturnDate = DateTime.UtcNow;
        }

        public void AddItem(DispenseReturnItem item)
        {
            _items.Add(item);
            TotalReturnedValue += item.TotalValue;
        }
    }
}
