using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Commands.CreateProduct
{
    /// <summary>
    /// Comando para criar um novo produto.
    /// </summary>
    public record CreateProductCommand(
        string Name,
        string Description,
        string DosageForm,
        string Category
    ) : IRequest<ApiResponse<int>>;
}
