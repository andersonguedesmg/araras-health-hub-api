using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory
{
    public record UpdateSubCategoryCommand(
        int Id,
        string Name,
        int MainCategoryId
    ) : IRequest<ApiResponse<object>>
    {
        public UpdateSubCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
