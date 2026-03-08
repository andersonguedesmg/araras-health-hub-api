using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.DeactivatePackagingType
{
    public sealed record DeactivatePackagingTypeCommand(int Id) : IRequest<Result>;
}
