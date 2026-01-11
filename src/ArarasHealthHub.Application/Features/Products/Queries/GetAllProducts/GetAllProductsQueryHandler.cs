using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Responses;
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
                var searchTerm = request.SearchTerm.Trim().ToLower();

                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(searchTerm) ||
                    p.Description.ToLower().Contains(searchTerm) ||
                    p.MainCategory!.Name.ToLower().Contains(searchTerm) ||
                    p.SubCategory!.Name.ToLower().Contains(searchTerm) ||
                    p.PresentationForm!.Name.ToLower().Contains(searchTerm)
                );
            }

            var totalCount = await productsQuery.CountAsync(cancellationToken);

            IOrderedQueryable<Product> orderedQuery;

            switch (request.OrderBy?.ToLower())
            {
                case "name":
                    orderedQuery = request.SortOrder?.ToLower() == "desc"
                        ? productsQuery.OrderByDescending(p => p.Name)
                        : productsQuery.OrderBy(p => p.Name);
                    break;
                case "maincategory":
                    orderedQuery = request.SortOrder?.ToLower() == "desc"
                        ? productsQuery.OrderByDescending(p => p.MainCategory!.Name)
                        : productsQuery.OrderBy(p => p.MainCategory!.Name);
                    break;
                case "subcategory":
                    orderedQuery = request.SortOrder?.ToLower() == "desc"
                        ? productsQuery.OrderByDescending(p => p.SubCategory!.Name)
                        : productsQuery.OrderBy(p => p.SubCategory!.Name);
                    break;
                default:
                    orderedQuery = productsQuery.OrderBy(p => p.Name);
                    break;
            }

            var pagedProducts = await orderedQuery
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
