using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Results;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        int MainCategoryId,
        int SubCategoryId,
        int PresentationFormId
    ) : IRequest<Result>
    {
        public UpdateProductCommand WithId(int id)
            => this with { Id = id };
    }
}
