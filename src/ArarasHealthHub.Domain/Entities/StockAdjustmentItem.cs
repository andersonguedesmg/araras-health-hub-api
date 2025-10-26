using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class StockAdjustmentItem : BaseEntity
    {
        [Required]
        [ForeignKey("Receiving")]
        public int StockAdjustmentId { get; set; }

        public StockAdjustment StockAdjustment { get; set; } = null!;

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Required]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalValue { get; set; }

        public string? Batch { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }
}
