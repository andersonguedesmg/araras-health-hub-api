using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArarasHealthHub.Application.Features.Products.Responses
{
    public record ProductListItemResponse(
        int Id,
        string Name,
        string Description,
        int MainCategoryId,
        string MainCategoryName,
        int SubCategoryId,
        string SubCategoryName,
        int PresentationFormId,
        string PresentationFormName,
        bool IsActive
    );
}
