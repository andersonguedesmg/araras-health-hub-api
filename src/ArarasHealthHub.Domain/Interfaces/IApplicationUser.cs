using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Domain.Interfaces
{
    public interface IApplicationUser
    {
        int Id { get; set; }

        string? UserName { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }

        bool IsActive { get; set; }

        int FacilityId { get; set; }
    }
}
