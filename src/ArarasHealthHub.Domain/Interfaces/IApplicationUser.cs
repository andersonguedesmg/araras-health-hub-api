using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Domain.Interfaces
{
    public interface IApplicationUser
    {
        int Id { get; set; }
        string? UserName { get; set; }
        int FacilityId { get; set; }
        public UserScopeEnum Scope { get; set; }
    }
}
