using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Role.Dtos;

namespace ArarasHealthHub.Application.Features.Account.Dtos
{
    public class NewUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public int UserId { get; set; }

        public bool IsActive { get; set; } = true;

        public int? FacilityId { get; set; }

        public List<RoleDto> Roles { get; set; } = new();

        public string Token { get; set; } = string.Empty;
    }
}
