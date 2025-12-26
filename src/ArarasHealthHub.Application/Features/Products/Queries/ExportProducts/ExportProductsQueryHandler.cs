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
                var searchTerm = request.SearchTerm.Trim().ToLower();

                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    p.Description.ToLower().Contains(searchTerm) ||
                    p.MainCategory!.Name.ToLower().Contains(searchTerm) ||
                    p.SubCategory!.Name.ToLower().Contains(searchTerm) ||
                    p.PresentationForm!.Name.ToLower().Contains(searchTerm)
                );
            }

            var allFilteredProducts = await productsQuery
                .OrderBy(p => p.Name)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ProductDto>>(allFilteredProducts);
        }
    }
}
