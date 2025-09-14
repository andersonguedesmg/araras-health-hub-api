using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.ExportProducts
{
    public class ExportProductsQueryHandler : IRequestHandler<ExportProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ExportProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(ExportProductsQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = _productRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                productsQuery = productsQuery.Where(p =>
                    p.Id.ToString().Contains(searchTermLower) ||
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Description.ToLower().Contains(searchTermLower) ||
                    p.DosageForm.ToLower().Contains(searchTermLower) ||
                    p.Category.ToLower().Contains(searchTermLower) ||
                    p.IsActive.ToString().ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredProducts = await productsQuery.ToListAsync(cancellationToken);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(allFilteredProducts);

            return productDtos;
        }
    }
}
