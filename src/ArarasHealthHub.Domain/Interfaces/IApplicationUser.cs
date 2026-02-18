using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Domain.Interfaces
{
    public interface IApplicationUser
    {
        int Id { get; }
        string? UserName { get; }
        int FacilityId { get; }
        AccountScopeEnum Scope { get; }
        AccountRoleEnum Role { get; }
        DateTime CreatedOn { get; }
        DateTime? UpdatedOn { get; }
        bool IsActive { get; }
    }
}
