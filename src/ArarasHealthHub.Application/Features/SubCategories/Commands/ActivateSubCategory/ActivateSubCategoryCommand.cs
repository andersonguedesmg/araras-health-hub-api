using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.ActivateSubCategory
{
    public sealed record ActivateSubCategoryCommand(int Id) : IRequest<Result>;
}
