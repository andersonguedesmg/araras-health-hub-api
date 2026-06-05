using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Exceptions;
using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class OrderReturn : BaseEntity
    {
        private readonly List<OrderReturnItem> _items = [];

        public int OriginalOrderId { get; private set; }
        public Order OriginalOrder { get; private set; } = null!;

        public string Reason { get; private set; } = null!;

        public DateTime ReturnedAt { get; private set; }

        public int ReturnedByEmployeeId { get; private set; }
        public Employee ReturnedByEmployee { get; private set; } = null!;

        public int ReturnedByAccountId { get; private set; }
        public ApplicationUser ReturnedByAccount { get; private set; } = null!;

        public decimal TotalReturnedValue { get; private set; }

        public IReadOnlyCollection<OrderReturnItem> Items =>
            _items.AsReadOnly();

        private OrderReturn() { }

        public OrderReturn(
            int originalOrderId,
            string reason,
            int returnedByEmployeeId,
            int returnedByAccountId)
        {
            if (originalOrderId <= 0)
            {
                throw new DomainException("Pedido original inválido.");
            }

            if (returnedByEmployeeId <= 0)
            {
                throw new DomainException("Funcionário inválido.");
            }

            if (returnedByAccountId <= 0)
            {
                throw new DomainException("Conta inválida.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new DomainException("Motivo da devolução é obrigatório.");
            }

            OriginalOrderId = originalOrderId;
            Reason = reason.Trim();

            ReturnedByEmployeeId = returnedByEmployeeId;
            ReturnedByAccountId = returnedByAccountId;

            ReturnedAt = DateTime.UtcNow;
        }

        public void AddItem(
            OrderReturnItem item)
        {
            ArgumentNullException.ThrowIfNull(item);

            _items.Add(item);

            TotalReturnedValue += item.TotalValue;

            SetUpdatedOn();
        }
    }
}
