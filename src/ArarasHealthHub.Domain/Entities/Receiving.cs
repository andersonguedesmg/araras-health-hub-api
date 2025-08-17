using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa o registro de entrada no estoque.")]
    public class Receiving : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required]
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
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        [Required]
        [ForeignKey("Responsible")]
        public int ResponsibleId { get; set; }

        public Employee? Responsible { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public ApplicationUser? Account { get; set; }

        public List<ReceivedItem> ReceivedItem { get; set; } = new();
    }
}
