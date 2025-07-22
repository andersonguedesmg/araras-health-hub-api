using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : PagedRequest, IRequest<PagedResponse<ProductDto>> { }
}
