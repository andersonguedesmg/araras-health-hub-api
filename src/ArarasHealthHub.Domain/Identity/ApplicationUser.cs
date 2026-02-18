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
        public int FacilityId { get; private set; }

        public Facility Facility { get; private set; } = null!;

        public AccountScopeEnum Scope { get; private set; }

        public AccountRoleEnum Role { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? UpdatedOn { get; private set; }

        public bool IsActive { get; private set; }

        private ApplicationUser() { }

        public ApplicationUser(
            string userName,
            int facilityId,
            AccountScopeEnum scope,
            AccountRoleEnum role,
            bool isActive)
        {
            UserName = userName;
            FacilityId = facilityId;
            Scope = scope;
            Role = role;
            IsActive = isActive;
            CreatedOn = DateTime.UtcNow;
        }

        public void Activate()
        {
            if (IsActive) return;

            IsActive = true;
            UpdatedOn = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            if (!IsActive) return;

            IsActive = false;
            UpdatedOn = DateTime.UtcNow;
        }
    }
}
