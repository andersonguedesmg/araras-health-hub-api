using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Models
{
    public class ReceivingItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Batch { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int ReceivingId { get; set; }

        public Receiving? Receiving { get; set; }
    }
}
