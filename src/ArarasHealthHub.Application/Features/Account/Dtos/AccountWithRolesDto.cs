
using ArarasHealthHub.Application.Features.Facility.Dtos;
using ArarasHealthHub.Application.Features.Role.Dtos;
using ArarasHealthHub.Domain.Entities;

namespace ArarasHealthHub.Application.Features.Account.Dtos
{
    public class AccountWithRolesDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string NormalizedUserName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public int FacilityId { get; set; }
        public FacilityDto Facility { get; set; } = new FacilityDto();
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
