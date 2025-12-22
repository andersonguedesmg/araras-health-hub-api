using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Common.Dtos;
using ArarasHealthHub.Application.Features.Accounts.Dtos;

namespace ArarasHealthHub.Application.Features.Facilities.Dtos
{
    public class FacilityProfileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cnes { get; set; } = string.Empty;
        public AddressDto Address { get; set; } = new AddressDto();
        public ContactDto Contact { get; set; } = new ContactDto();
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<AccountDetailsDto> FacilityAccounts { get; set; } = new List<AccountDetailsDto>();
    }
}
