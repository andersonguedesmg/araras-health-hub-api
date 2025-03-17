using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Supplier
{
    public class CreateSupplierRequestDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Nome não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Nome não pode ter mais de 280 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18, ErrorMessage = "O CNPJ precisa ter 18 caracteres.")]
        public string Cnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Endereço não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Endereço não pode ter mais de 280 caracteres.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Número é obrigatório.")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [MinLength(5, ErrorMessage = "O Bairro não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O Bairro não pode ter mais de 280 caracteres.")]
        public string Neighborhood { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        [MinLength(5, ErrorMessage = "A Cidade não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "A Cidade não pode ter mais de 280 caracteres.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "O Estado precisa ter 2 caracteres.")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(10, ErrorMessage = "O CEP precisa ter 10 caracteres.")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [MinLength(5, ErrorMessage = "O E-mail não pode ter menos de 5 caracteres.")]
        [MaxLength(280, ErrorMessage = "O E-mail não pode ter mais de 280 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [MinLength(14, ErrorMessage = "O Telefone não pode ter menos de 14 caracteres.")]
        [MaxLength(15, ErrorMessage = "O Telefone não pode ter mais de 15 caracteres.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Criação é obrigatória.")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; }

        [Required(ErrorMessage = "O Status é obrigatório.")]
        public bool IsActive { get; set; } = true;
    }
}
