using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Entities;
using ArarasHealthHub.Shared.Core.Pagination;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<ProductDto>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _productRepository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(p =>
                    p.Name.ToLower().Contains(term) ||
                    p.Description.ToLower().Contains(term) ||
                    p.MainCategory!.Name.ToLower().Contains(term) ||
                    p.SubCategory!.Name.ToLower().Contains(term) ||
                    p.PresentationForm!.Name.ToLower().Contains(term)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var orderingColumns = new Dictionary<string, Expression<Func<Product, object>>>
            {
                ["name"] = p => p.Name,
                ["maincategory"] = p => p.MainCategory!.Name,
                ["subcategory"] = p => p.MainCategory!.Name,
                ["presentationform"] = p => p.PresentationForm!.Name,
            };

            queryable = queryable.ApplyOrdering(
                request.OrderBy?.ToLower(),
                request.SortOrder?.ToLower() ?? "asc",
                orderingColumns
            );

            queryable = queryable.ApplyPagination(
                request.PageNumber,
                request.PageSize
            );

            var items = await queryable.ToListAsync(cancellationToken);

            var dtoList = _mapper.Map<IReadOnlyList<ProductDto>>(items);

            return PagedResponse<ProductDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                dtoList
            );
        }
    }
}
