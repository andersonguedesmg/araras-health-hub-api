using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Account
{
    public class UpdateUserNameDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
