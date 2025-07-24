using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class UpdateAccountDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
