using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryById
{
    public record GetMainCategoryByIdQuery(int Id) : IRequest<ApiResponse<MainCategoryDto>>
    {
        public GetMainCategoryByIdQuery WithId(int id)
            => this with { Id = id };
    }
}
