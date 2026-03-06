using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.SubCategories.Commands.UpdateSubCategory
{
    public record UpdateSubCategoryCommand(
        int Id,
        string Name,
        int MainCategoryId
    ) : IRequest<Result>
    {
        public UpdateSubCategoryCommand WithId(int id)
            => this with { Id = id };
    }
}
