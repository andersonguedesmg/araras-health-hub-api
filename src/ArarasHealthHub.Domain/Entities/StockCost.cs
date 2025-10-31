using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Armazena o custo médio unitário e o custo total atual do estoque consolidado.")]
    [Index(nameof(StockId), IsUnique = true)]
    public class StockCost : BaseEntity
    {
        [Required]
        [ForeignKey("Stock")]
        public int StockId { get; set; }
        public Stock Stock { get; set; } = null!;

        [Column(TypeName = "decimal(18,4)")]
        public decimal AverageUnitCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentTotalCost { get; set; }
    }
}
