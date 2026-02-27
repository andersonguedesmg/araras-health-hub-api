using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.MainCategories.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Queries.GetAllMainCategories
{
    public class GetAllMainCategoriesQuery : PagedRequest, IRequest<PagedResult<MainCategoryListItemResponse>> { }
}
