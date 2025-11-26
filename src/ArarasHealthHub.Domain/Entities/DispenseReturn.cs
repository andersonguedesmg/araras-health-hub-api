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
    [Comment("Representa uma devolução de itens dispensados de um pedido ao estoque.")]
    public class DispenseReturn : BaseEntity
    {
        [Required]
        [ForeignKey("OriginalOrder")]
        public int OriginalOrderId { get; set; }
        public Order OriginalOrder { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        [ForeignKey("ReturnedByEmployee")]
        public int ReturnedByEmployeeId { get; set; }
        public Employee ReturnedByEmployee { get; set; } = null!;

        [Required]
        [ForeignKey("ReturnedByAccount")]
        public int ReturnedByAccountId { get; set; }
        public ApplicationUser ReturnedByAccount { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalReturnedValue { get; set; }

        public ICollection<DispenseReturnItem> ReturnItems { get; set; } = new List<DispenseReturnItem>();
    }
}
