using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class AccountDetailsDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public AccountScopeEnum Scope { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public FacilityDetailsDto? Facility { get; set; }
    }
}
