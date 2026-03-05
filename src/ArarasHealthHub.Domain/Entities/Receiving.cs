using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Identity;

namespace ArarasHealthHub.Domain.Entities
{
    public class Receiving : BaseEntity
    {
        public string InvoiceNumber { get; private set; } = string.Empty;

        public string SupplyAuthorization { get; private set; } = string.Empty;

        public string? Observation { get; private set; }

        public DateTime ReceivingDate { get; private set; }

        public decimal TotalValue { get; private set; }

        public int SupplierId { get; private set; }
        public Supplier Supplier { get; private set; } = null!;

        public int ResponsibleId { get; private set; }
        public Employee Responsible { get; private set; } = null!;

        public int AccountId { get; private set; }
        public ApplicationUser Account { get; private set; } = null!;

        public ICollection<ReceivedItem> ReceivedItems { get; private set; } = new List<ReceivedItem>();

        private Receiving() { }

        public Receiving(
            string invoiceNumber,
            string supplyAuthorization,
            DateTime receivingDate,
            decimal totalValue,
            int supplierId,
            int responsibleId,
            int accountId,
            string? observation)
        {
            InvoiceNumber = invoiceNumber;
            SupplyAuthorization = supplyAuthorization;
            ReceivingDate = receivingDate;
            TotalValue = totalValue;
            SupplierId = supplierId;
            ResponsibleId = responsibleId;
            AccountId = accountId;
            Observation = observation;
        }
    }
}
