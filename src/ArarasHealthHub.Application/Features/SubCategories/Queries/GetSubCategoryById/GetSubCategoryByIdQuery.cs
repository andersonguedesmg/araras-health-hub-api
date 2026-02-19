using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Dtos;
using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById
{
    public record GetSubCategoryByIdQuery(int Id) : IRequest<ApiResponse<SubCategoryDto>>
    {
        public GetSubCategoryByIdQuery WithId(int id)
            => this with { Id = id };
    }
}
