using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.PackagingTypes.Responses;
using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Queries.GetPackagingTypeById
{
    public record GetPackagingTypeByIdQuery(int Id) : IRequest<Result<PackagingTypeResponse>>;
}
