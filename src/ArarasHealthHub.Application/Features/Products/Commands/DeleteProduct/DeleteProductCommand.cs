using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(
        int Id
    ) : IRequest<ApiResponse<bool>>;
}
