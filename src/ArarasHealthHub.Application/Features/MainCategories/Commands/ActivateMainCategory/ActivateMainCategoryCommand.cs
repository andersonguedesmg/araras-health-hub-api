using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.ActivateMainCategory
{
    public record ActivateMainCategoryCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public ActivateMainCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
