using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : PagedRequest, IRequest<PagedResult<ProductListItemResponse>> { }
}
