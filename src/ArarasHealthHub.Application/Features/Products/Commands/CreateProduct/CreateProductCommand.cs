using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Shared.Responses;

using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        int MainCategoryId,
        int SubCategoryId,
        int PresentationFormId
    ) : IRequest<ApiResponse<int>>;
}
