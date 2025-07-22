using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.ChangeStatusProduct
{
    /// <summary>
    /// Comando para alterar o status de um produto.
    /// </summary>
    public record ChangeStatusProductCommand(
        int Id,
        bool IsActive
    ) : IRequest<ApiResponse<bool>>;
}
