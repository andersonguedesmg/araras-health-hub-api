using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Employee
{
    public class ChangeStatusEmployeeRequestDto
    {
        [Required(ErrorMessage = "O Status é obrigatório.")]
        public bool IsActive { get; set; } = true;
    }
}
