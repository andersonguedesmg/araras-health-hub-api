using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Dtos;
using ArarasHealthHub.Shared.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetProductDropdown
{
    public class GetProductDropdownQueryHandler : IRequestHandler<GetProductDropdownQuery, PagedResponse<DropdownItemDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDropdownQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResponse<DropdownItemDto>> Handle(
            GetProductDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _productRepository
                .AsQueryableWithIncludes()
                .Where(p => p.IsActive);

            var term = request.SearchTerm?.Trim();

            if (!string.IsNullOrWhiteSpace(term))
            {
                var search = term.ToLower();

                queryable = queryable.Where(p =>
                    p.Name.ToLower().Contains(search)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var items = await queryable
                .OrderBy(x => x.Name)
                .ApplyPagination(request.PageNumber, request.PageSize)
                .Select(x => new DropdownItemDto
                {
                    Id = x.Id,
                    Label = x.Name
                })
                .ToListAsync(cancellationToken);

            return PagedResponse<DropdownItemDto>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
