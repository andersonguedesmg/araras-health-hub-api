using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.DeleteProduct
{
    /// <summary>
    /// Comando para excluir um produto.
    /// </summary>
    public record DeleteProductCommand(
        int Id
    ) : IRequest<ApiResponse<bool>>;
}
