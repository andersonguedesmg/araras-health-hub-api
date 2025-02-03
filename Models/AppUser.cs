using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace araras_health_hub_api.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
    }
}
