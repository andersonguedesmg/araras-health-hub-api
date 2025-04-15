using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Account
{
    public class NewUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public int UserId { get; set; }

        public bool IsActive { get; set; } = true;

        public int? DestinationId { get; set; }

        public List<RoleDto> Roles { get; set; } = new();

        public string Token { get; set; } = string.Empty;
    }
}
