using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.CreateSubCategory
{
    public record CreateSubCategoryCommand(
        string Name,
        int MainCategoryId
    ) : IRequest<Result<int>>;
}
