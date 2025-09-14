using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.ExportProducts
{
    public class ExportProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public string? SearchTerm { get; set; }
    }
}
