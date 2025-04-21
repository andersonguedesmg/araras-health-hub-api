using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Models
{
    public class Receiving
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public string SupplyAuthorization { get; set; } = string.Empty;

        public string? Observation { get; set; } = string.Empty;

        public DateTime ReceivingDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalValue { get; set; }

        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public int ResponsibleId { get; set; }

        public Employee? Responsible { get; set; }

        public int AccountId { get; set; }

        public AppUser? Account { get; set; }

        public List<ReceivingItem> ReceivedItems { get; set; } = new();
    }
}
