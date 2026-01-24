using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdown
{
    public class GetProductDropdownQuery : PagedRequest, IRequest<PagedResponse<ProductNameDto>> { }
}
