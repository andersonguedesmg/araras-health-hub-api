using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Models
{
    public class Receiving
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public string SupplyAuthorization { get; set; } = string.Empty;

        public string Observation { get; set; } = string.Empty;

        public DateTime ReceivingDate { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; } = null!;

        public int ResponsibleId { get; set; }

        public User Responsible { get; set; } = null!;

        public int AccountId { get; set; }

        public AppUser Account { get; set; } = null!;

        public List<ReceivingItem> ReceivedItems { get; set; } = new();
    }
}
