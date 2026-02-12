using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int FacilityId { get; set; }
        public string Role { get; set; } = string.Empty;
        public AccountScopeEnum Scope { get; set; } = AccountScopeEnum.Operational;
        public bool IsActive { get; set; } = true;
    }
}
