using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(100)]
        public string MainCategory { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string SubCategory { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string PresentationForm { get; set; } = string.Empty;

        public Stock? Stock { get; set; }
    }
}
