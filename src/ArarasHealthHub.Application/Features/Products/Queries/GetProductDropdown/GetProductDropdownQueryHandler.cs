using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Products.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Core.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdown
{
    public class GetProductDropdownQueryHandler : IRequestHandler<GetProductDropdownQuery, PagedResponse<ProductNameDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDropdownQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResponse<ProductNameDto>> Handle(
            GetProductDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _productRepository
                .GetQueryable()
                .Where(e => e.IsActive);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();
                queryable = queryable.Where(e => e.Name.ToLower().Contains(term));
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            queryable = queryable
                .OrderBy(e => e.Name)
                .ApplyPagination(request.PageNumber, request.PageSize);

            var items = await queryable
                .Select(e => new ProductNameDto
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<ProductNameDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
