using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class AccountCreatedDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public AccountScopeEnum Scope { get; set; }
        public int FacilityId { get; set; }
    }
}
