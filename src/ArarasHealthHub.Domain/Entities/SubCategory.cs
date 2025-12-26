using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Subcategoria vinculada a uma categoria principal (ex: Antibiótico, Analgésico, Antialérgico)")]
    public class SubCategory : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int MainCategoryId { get; set; }

        [ForeignKey("MainCategoryId")]
        public MainCategory? MainCategory { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
