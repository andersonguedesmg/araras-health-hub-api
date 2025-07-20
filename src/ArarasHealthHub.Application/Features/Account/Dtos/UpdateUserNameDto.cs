using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Account.Dtos
{
    public class UpdateUserNameDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
