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
        [MaxLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        public string SupplyAuthorization { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Observation { get; set; } = string.Empty;

        [Required]
        public DateTime ReceivingDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalValue { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        [Required]
        public int ResponsibleId { get; set; }

        public Employee? Responsible { get; set; }

        [Required]
        public int AccountId { get; set; }

        public ApplicationUser? Account { get; set; }

        public List<ReceivingItem> ReceivingItems { get; set; } = new();
    }
}
