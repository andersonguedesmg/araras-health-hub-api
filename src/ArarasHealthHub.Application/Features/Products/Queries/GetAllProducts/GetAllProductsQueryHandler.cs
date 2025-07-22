using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var allProducts = await _productRepository.GetAllAsync();

            var totalCount = allProducts.Count();

            IOrderedEnumerable<Product> orderedProducts;
            switch (request.OrderBy.ToLower())
            {
                case "name":
                    orderedProducts = request.SortOrder.ToLower() == "desc" ?
                        allProducts.OrderByDescending(s => s.Name) :
                        allProducts.OrderBy(s => s.Name);
                    break;
                case "category":
                    orderedProducts = request.SortOrder.ToLower() == "desc" ?
                        allProducts.OrderByDescending(s => s.Category) :
                        allProducts.OrderBy(s => s.Category);
                    break;
                default:
                    orderedProducts = request.SortOrder.ToLower() == "desc" ?
                        allProducts.OrderByDescending(s => s.Id) :
                        allProducts.OrderBy(s => s.Id);
                    break;
            }

            var pagedProducts = orderedProducts
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var productDtos = _mapper.Map<List<ProductDto>>(pagedProducts);

            return new PagedResponse<ProductDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                productDtos
            );
        }
    }
}
