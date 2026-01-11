using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory
{
    public record CreateSubCategoryCommand(
        string Name,
        int MainCategoryId
    ) : IRequest<ApiResponse<int>>;
}
