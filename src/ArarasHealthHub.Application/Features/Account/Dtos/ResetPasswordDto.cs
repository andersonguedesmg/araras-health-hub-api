using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Account.Dtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;
    }
}
