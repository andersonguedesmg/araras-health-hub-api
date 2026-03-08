using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Responses
{
    public record PackagingTypeListItemResponse(
        int Id,
        string Name,
        bool IsActive
    );
}
