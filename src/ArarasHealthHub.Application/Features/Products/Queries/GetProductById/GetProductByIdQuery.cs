using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Shared.Core;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductById
{
    /// <summary>
    /// Query para obter um produto pelo seu ID.
    /// </summary>
    public record GetProductByIdQuery(int Id) : IRequest<ApiResponse<ProductDto>>;
}
