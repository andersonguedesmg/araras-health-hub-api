using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class LoginResponseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int FacilityId { get; set; }
        public UserScopeEnum Scope { get; set; }
        public string Token { get; set; } = string.Empty;
        public List<UserRoleDto> Roles { get; set; } = new();
    }

    public class UserRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
