using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Product
{
    public class CreateProductRequestDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Nome não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Nome não pode ter mais de 280 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        [MinLength(5, ErrorMessage = "A Descrição não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Descrição não pode ter mais de 280 caracteres.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Unidade de Medida é obrigatório.")]
        [MinLength(5, ErrorMessage = "A Unidade de Medida não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Unidade de Medida não pode ter mais de 280 caracteres.")]
        public string DosageForm { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Categoria é obrigatória.")]
        [MinLength(5, ErrorMessage = "A Categoria não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Categoria não pode ter mais de 280 caracteres.")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Criação é obrigatória.")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Status é obrigatório.")]
        public bool IsActive { get; set; } = true;
    }
}
