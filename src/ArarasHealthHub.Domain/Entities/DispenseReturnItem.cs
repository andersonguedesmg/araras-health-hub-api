using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Entities
{
    public class DispenseReturnItem : BaseEntity
    {
        [Required]
        [ForeignKey("DispenseReturn")]
        public int DispenseReturnId { get; set; }
        public DispenseReturn DispenseReturn { get; set; } = null!;

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        [ForeignKey("StockLot")]
        public int StockLotId { get; set; }
        public StockLot StockLot { get; set; } = null!;

        [Required]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalValue { get; set; }

        [Required]
        [MaxLength(50)]
        public string Batch { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
