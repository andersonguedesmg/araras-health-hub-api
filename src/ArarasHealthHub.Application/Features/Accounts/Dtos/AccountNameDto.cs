using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Facilities.Dtos;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class AccountNameDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public FacilityNameDto? Facility { get; set; }
    }
}
