using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Responses
{

    public record PackagingTypeResponse(
        int Id,
        string Name,
        DateTime CreatedOn,
        DateTime UpdatedOn,
        bool IsActive
    );
}
