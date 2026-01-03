using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetMainCategoryDropdownOptions
{
    public record GetMainCategoryDropdownOptionsQuery() : IRequest<ApiResponse<List<MainCategoryNameDto>>>;
}
