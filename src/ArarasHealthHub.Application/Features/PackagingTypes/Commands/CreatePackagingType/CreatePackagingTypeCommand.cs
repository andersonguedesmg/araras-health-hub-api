using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.CreatePackagingType
{
    public record CreatePackagingTypeCommand(
        string Name
    ) : IRequest<Result<int>>;
}
