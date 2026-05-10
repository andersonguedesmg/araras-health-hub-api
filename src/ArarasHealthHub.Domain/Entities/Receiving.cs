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
    public class Receiving : BaseEntity
    {
        private readonly List<ReceivedItem> _items = [];

        public string InvoiceNumber { get; private set; } = string.Empty;

        public string SupplyAuthorization { get; private set; } = string.Empty;

        public string? Observation { get; private set; }

        public DateTime ReceivingDate { get; private set; }

        public decimal TotalValue
            => _items.Sum(x => x.TotalValue);

        public int SupplierId { get; private set; }
        public Supplier Supplier { get; private set; } = null!;

        public int ResponsibleId { get; private set; }
        public Employee Responsible { get; private set; } = null!;

        public int AccountId { get; private set; }
        public ApplicationUser Account { get; private set; } = null!;

        public IReadOnlyCollection<ReceivedItem> Items => _items;

        private Receiving() { }

        public Receiving(
            string invoiceNumber,
            string supplyAuthorization,
            DateTime receivingDate,
            int supplierId,
            int responsibleId,
            int accountId,
            string? observation = null)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
                throw new DomainException(
                    "Número da nota fiscal é obrigatório."
                );

            if (receivingDate > DateTime.UtcNow)
                throw new DomainException(
                    "Data de recebimento não pode ser futura."
                );

            InvoiceNumber = invoiceNumber.Trim();
            SupplyAuthorization = supplyAuthorization.Trim();
            ReceivingDate = receivingDate;

            SupplierId = supplierId;
            ResponsibleId = responsibleId;
            AccountId = accountId;

            Observation = observation?.Trim();
        }

        public void AddItem(ReceivedItem item)
        {
            if (item is null)
                throw new DomainException(
                    "Item do recebimento é obrigatório."
                );

            _items.Add(item);

            SetUpdatedOn();
        }

        public void RemoveItem(ReceivedItem item)
        {
            if (!_items.Remove(item))
                throw new DomainRuleException(
                    "Item não encontrado no recebimento."
                );

            SetUpdatedOn();
        }
    }
}
