using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
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
    ) : IRequest<ApiResponse<bool>>;
}
