using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class ResetPasswordDto
    {
        public string UserName { get; set; } = null!;

        public string NewPassword { get; set; } = null!;
    }
}
