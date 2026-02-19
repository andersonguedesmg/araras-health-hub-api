using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories
{
    public class GetAllMainCategoriesQuery : PagedRequest, IRequest<PagedResponse<MainCategoryDto>> { }
}
