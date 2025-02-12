using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.User
{
    public class UpdateUserRequestDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Nome não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Nome não pode ter mais de 280 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Função é obrigatória.")]
        [MinLength(5, ErrorMessage = "A Função não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Função não pode ter mais de 280 caracteres.")]
        public string Function { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [MinLength(14, ErrorMessage = "O Telefone não pode ter menos de 14 caracteres.")]
        [MaxLength(15, ErrorMessage = "O Telefone não pode ter mais de 15 caracteres.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Atualização é obrigatória.")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Status é obrigatório.")]
        public bool IsActive { get; set; } = true;
    }
}
