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
using Microsoft.EntityFrameworkCore;

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
            var productsQuery = _productRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();
                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTermLower) ||
                    p.Description.ToLower().Contains(searchTermLower) ||
                    p.MainCategory.ToLower().Contains(searchTermLower) ||
                    p.SubCategory.ToLower().Contains(searchTermLower) ||
                    p.PresentationForm.ToLower().Contains(searchTermLower)
                );
            }

            var totalCount = await productsQuery.CountAsync(cancellationToken);

            IQueryable<Product> orderedProducts;
            switch (request.OrderBy?.ToLower())
            {
                case "name":
                    orderedProducts = request.SortOrder?.ToLower() == "desc" ?
                        productsQuery.OrderByDescending(s => s.Name) :
                        productsQuery.OrderBy(s => s.Name);
                    break;
                case "maincategory":
                    orderedProducts = request.SortOrder?.ToLower() == "desc" ?
                        productsQuery.OrderByDescending(s => s.MainCategory) :
                        productsQuery.OrderBy(s => s.MainCategory);
                    break;
                case "subcategory":
                    orderedProducts = request.SortOrder?.ToLower() == "desc" ?
                        productsQuery.OrderByDescending(s => s.SubCategory) :
                        productsQuery.OrderBy(s => s.SubCategory);
                    break;
                default:
                    orderedProducts = request.SortOrder?.ToLower() == "desc" ?
                        productsQuery.OrderByDescending(s => s.Id) :
                        productsQuery.OrderBy(s => s.Id);
                    break;
            }

            var pagedProducts = await orderedProducts
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

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
