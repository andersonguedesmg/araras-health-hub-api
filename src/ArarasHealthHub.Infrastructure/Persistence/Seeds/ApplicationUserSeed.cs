using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Infrastructure.Persistence.Seeds
{
    public class ApplicationUserSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new
                {
                    Id = 1,
                    UserName = "saude_master",
                    NormalizedUserName = "SAUDE_MASTER",
                    FacilityId = 1,
                    Scope = AccountScopeEnum.Management,
                    Role = AccountRoleEnum.Master,
                    CreatedOn = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true,
                    SecurityStamp = "D8A2F6E1-7B32-4C6F-BB5A-91C3E62E8A11",
                    ConcurrencyStamp = "3F1C7B9A-1C8E-4E3B-A4F5-8C6B7F2E1D99",
                    PasswordHash = "AQAAAAIAAYagAAAAEEqeBGF+Rvx70SKaJEf8a7fAWWMLi+icLvnqu5uiLw3uR23FB+X6dxnr0jBGFs2ZnA==",

                    Email = "",
                    NormalizedEmail = "",
                    EmailConfirmed = false,
                    PhoneNumber = (string?)null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = (DateTimeOffset?)null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                }
            );
        }
    }
}
