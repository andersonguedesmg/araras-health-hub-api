using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Products.Responses;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResult<ProductListItemResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResult<ProductListItemResponse>> Handle(
            GetAllProductsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _productRepository
                .AsQueryable()
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(p =>
                    EF.Functions.Like(p.Name, $"%{term}%") ||
                    EF.Functions.Like(p.Description, $"%{term}%") ||
                    EF.Functions.Like(p.MainCategory!.Name, $"%{term}%") ||
                    EF.Functions.Like(p.SubCategory!.Name, $"%{term}%") ||
                    EF.Functions.Like(p.PresentationForm!.Name, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "name" => request.SortOrder == "desc"
                    ? query.OrderByDescending(p => p.Name)
                    : query.OrderBy(p => p.Name),

                "description" => request.SortOrder == "desc"
                    ? query.OrderByDescending(p => p.Description)
                    : query.OrderBy(p => p.Description),

                "maincategory" => request.SortOrder == "desc"
                    ? query.OrderByDescending(p => p.MainCategory!.Name)
                    : query.OrderBy(p => p.MainCategory!.Name),

                "subcategory" => request.SortOrder == "desc"
                    ? query.OrderByDescending(p => p.SubCategory!.Name)
                    : query.OrderBy(p => p.SubCategory!.Name),

                "presentationform" => request.SortOrder == "desc"
                    ? query.OrderByDescending(p => p.PresentationForm!.Name)
                    : query.OrderBy(p => p.PresentationForm!.Name),

                _ => query.OrderBy(p => p.Name)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProductListItemResponse(
                    p.Id,
                    p.Name,
                    p.Description,
                    p.MainCategoryId,
                    p.MainCategory!.Name,
                    p.SubCategoryId,
                    p.SubCategory!.Name,
                    p.PresentationFormId,
                    p.PresentationForm!.Name,
                    p.IsActive))
                .ToListAsync(cancellationToken);

            return PagedResult<ProductListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Produtos listados com sucesso.");
        }
    }
}
