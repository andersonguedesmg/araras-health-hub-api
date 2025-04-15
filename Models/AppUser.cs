using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace araras_health_hub_api.Models
{
    public class AppUser : IdentityUser<int>
    {
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.MinValue;

        public bool IsActive { get; set; } = true;

        public int FacilityId { get; set; }

        public Facility? Facility { get; set; }
    }
}
