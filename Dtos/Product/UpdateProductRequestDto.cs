using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Nome não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Nome não pode ter mais de 280 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [MinLength(5, ErrorMessage = "A Descrição não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Descrição não pode ter mais de 280 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Fabricante é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Fabricante não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Fabricante não pode ter mais de 280 caracteres.")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Medida é obrigatório.")]
        [MinLength(5, ErrorMessage = "A Medida não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Medida não pode ter mais de 280 caracteres.")]
        public string Format { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Categoria é obrigatória.")]
        [MinLength(5, ErrorMessage = "A Categoria não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Categoria não pode ter mais de 280 caracteres.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Atualização é obrigatória.")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
