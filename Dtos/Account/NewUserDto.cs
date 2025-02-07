using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace araras_health_hub_api.Dtos.Account
{
    public class NewUserDto
    {
        public string UserName { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public string Token { get; set; } = string.Empty;
    }
}
