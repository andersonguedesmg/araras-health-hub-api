using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa um ajuste manual na quantidade do estoque.")]
    public class StockAdjustment : BaseEntity
    {
        public StockAdjustmentType Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Reason { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Observation { get; set; } = string.Empty;

        [Required]
        public DateTime AdjustmentDate { get; set; }

        [Required]
        [ForeignKey("Responsible")]
        public int ResponsibleId { get; set; }

        public Employee? Responsible { get; set; }

        [Required]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public ApplicationUser? Account { get; set; }

        public ICollection<StockAdjustmentItem> AdjustmentItems { get; set; } = new List<StockAdjustmentItem>();
    }
}
