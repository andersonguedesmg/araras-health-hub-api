using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Accounts.Dtos
{
    public class AccountDetailsDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public FacilityDetailsDto? Facility { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }

    public class FacilityDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string Neighborhood { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
