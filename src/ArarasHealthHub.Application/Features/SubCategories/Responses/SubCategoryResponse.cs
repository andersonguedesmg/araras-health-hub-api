using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.SubCategories.Responses
{
    public record SubCategoryResponse(
        int Id,
        string Name,
        int MainCategoryId,
        string MainCategoryName,
        DateTime CreatedOn,
        DateTime UpdatedOn,
        bool IsActive
    );
}
