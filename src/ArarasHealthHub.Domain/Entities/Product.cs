using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Domain.Entities
{
    [Comment("Representa um produto.")]
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [ForeignKey("MainCategoryId")]
        public int MainCategoryId { get; set; }
        public MainCategory? MainCategory { get; set; }

        [Required]
        [ForeignKey("SubCategoryId")]
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }

        [Required]
        [ForeignKey("PresentationFormId")]
        public int PresentationFormId { get; set; }
        public PresentationForm? PresentationForm { get; set; }

        public Stock? Stock { get; set; }
    }
}
