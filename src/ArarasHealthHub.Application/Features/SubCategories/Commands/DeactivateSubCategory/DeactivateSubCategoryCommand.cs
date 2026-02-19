using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.DeactivateSubCategory
{
    public record DeactivateSubCategoryCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivateSubCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
