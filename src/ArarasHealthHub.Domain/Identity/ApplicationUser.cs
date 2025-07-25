using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Domain.Identity
{
    public class ApplicationUser : IdentityUser<int>, IApplicationUser
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedOn { get; set; } = DateTime.MinValue;

        public bool IsActive { get; set; } = true;

        public int FacilityId { get; set; }

        public Facility? Facility { get; set; }
    }
}
