using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory
{
    public record ActivateSubCategoryCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivateSubCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
