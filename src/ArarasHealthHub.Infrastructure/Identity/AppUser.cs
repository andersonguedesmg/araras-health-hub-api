using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Infrastructure.Identity
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
