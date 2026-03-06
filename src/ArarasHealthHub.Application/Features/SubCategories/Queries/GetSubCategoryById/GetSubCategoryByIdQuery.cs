using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.SubCategories.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Queries.GetSubCategoryById
{
    public record GetSubCategoryByIdQuery(int Id) : IRequest<Result<SubCategoryResponse>>;
}
