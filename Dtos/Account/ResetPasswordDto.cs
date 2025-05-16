using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Account
{
    public class ResetPasswordDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;
    }
}
