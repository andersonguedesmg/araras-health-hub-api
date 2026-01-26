using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.DeleteMainCategory
{
    public record DeleteMainCategoryCommand(int Id) : IRequest<ApiResponse<object>>
    {
        public DeleteMainCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
