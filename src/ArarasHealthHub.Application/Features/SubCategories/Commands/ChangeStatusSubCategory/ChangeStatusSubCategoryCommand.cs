using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ChangeStatusSubCategory
{
    public record ChangeStatusSubCategoryCommand(
        int Id,
        bool IsActive
    ) : IRequest<ApiResponse<bool>>;
}
