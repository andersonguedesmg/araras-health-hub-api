using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.DeactivateMainCategory
{
    public record DeactivateMainCategoryCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeactivateMainCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
