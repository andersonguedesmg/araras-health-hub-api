using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.UpdateProduct
{
    /// <summary>
    /// Comando para atualizar um produto existente.
    /// </summary>
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        string DosageForm,
        string Category
    ) : IRequest<ApiResponse<bool>>;
}
