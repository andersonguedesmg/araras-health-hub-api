using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.PackagingTypes.Commands.UpdatePackagingType
{
    public record UpdatePackagingTypeCommand(
        int Id,
        string Name
    ) : IRequest<Result>
    {
        public UpdatePackagingTypeCommand WithId(int id)
            => this with { Id = id };
    }
}
