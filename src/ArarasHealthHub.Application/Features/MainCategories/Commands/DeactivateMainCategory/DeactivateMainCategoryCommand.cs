using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.MainCategories.Commands.DeactivateMainCategory
{
    public sealed record DeactivateMainCategoryCommand(int Id) : IRequest<Result>;
}
