using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class ReceivingItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalValue { get; set; }

        public string Batch { get; set; } = string.Empty;

        public DateTime ExpiryDate { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public int ReceivingId { get; set; }

        public Receiving Receiving { get; set; } = null!;
    }
}
