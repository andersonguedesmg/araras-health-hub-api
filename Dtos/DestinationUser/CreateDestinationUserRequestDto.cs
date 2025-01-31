using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.DestinationUser
{
    public class CreateDestinationUserRequestDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Nome não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Nome não pode ter mais de 280 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Senha é obrigatório.")]
        [MinLength(5, ErrorMessage = "A Senha não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Senha não pode ter mais de 280 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Tipo de Usuário é obrigatório.")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Criação é obrigatória.")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; }

        [Required(ErrorMessage = "O Status é obrigatório.")]
        public bool IsActive { get; set; } = true;
    }
}
