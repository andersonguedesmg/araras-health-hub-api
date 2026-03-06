using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.SubCategories.Responses
{
    public record SubCategoryListItemResponse(
        int Id,
        string Name,
        int MainCategoryId,
        string MainCategoryName,
        bool IsActive
    );
}
