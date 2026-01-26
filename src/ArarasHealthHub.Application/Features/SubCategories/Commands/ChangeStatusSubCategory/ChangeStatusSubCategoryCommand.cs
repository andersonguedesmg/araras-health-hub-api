using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ChangeStatusSubCategory
{
    public record ChangeStatusSubCategoryCommand(
        int Id,
        bool IsActive
    ) : IRequest<ApiResponse<object>>
    {
        public ChangeStatusSubCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
