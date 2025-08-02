using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa um ajuste manual na quantidade do estoque.")]
    public class StockAdjustment : BaseEntity
    {
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        [Comment("Quantidade ajustada. Pode ser positiva (adicionar) ou negativa (remover).")]
        public decimal Quantity { get; set; }

        [Required]
        [MaxLength(250)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Responsible")]
        public int ResponsibleId { get; set; }
        public Employee Responsible { get; set; } = null!;
    }
}
