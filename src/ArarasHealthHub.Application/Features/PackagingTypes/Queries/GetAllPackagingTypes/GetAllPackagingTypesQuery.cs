using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Responses;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetAllPackagingTypes
{
    public class GetAllPackagingTypesQuery : PagedRequest, IRequest<PagedResult<PackagingTypeListItemResponse>> { }
}
