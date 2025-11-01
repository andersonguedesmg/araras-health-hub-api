using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Domain.Identity
{
    public class ApplicationUser : IdentityUser<int>, IApplicationUser
    {
        public int FacilityId { get; set; }

        public Facility? Facility { get; set; }

        public UserScopeEnum Scope { get; set; } = UserScopeEnum.Unassigned;
    }
}
