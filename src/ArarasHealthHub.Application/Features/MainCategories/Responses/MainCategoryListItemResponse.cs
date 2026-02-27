using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.MainCategories.Responses
{
    public record MainCategoryListItemResponse(
        int Id,
        string Name,
        bool IsActive
    );
}
