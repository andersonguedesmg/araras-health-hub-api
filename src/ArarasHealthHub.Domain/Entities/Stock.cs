using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa o estoque atual de um produto (visão consolidada).")]
    [Index(nameof(ProductId), IsUnique = true)]
    public class Stock : BaseEntity
    {
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Comment("Quantidade total disponível de todas as validades e lotes.")]
        public decimal CurrentQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Comment("Quantidade que está reservada para pedidos pendentes/aprovados.")]
        public decimal ReservedQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Comment("Quantidade disponível para novas reservas (CurrentQuantity - ReservedQuantity).")]
        public decimal AvailableQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal MinQuantity { get; set; }

        public StockCost? StockCost { get; set; }

        public ICollection<StockLot> Lots { get; set; } = new List<StockLot>();
    }
}
