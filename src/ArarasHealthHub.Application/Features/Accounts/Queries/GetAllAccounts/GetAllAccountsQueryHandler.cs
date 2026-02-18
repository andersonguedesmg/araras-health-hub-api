using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core.Pagination;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, PagedResponse<AccountListItemResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAccountsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<AccountListItemResponse>> Handle(
            GetAllAccountsQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = _context.Set<ApplicationUser>()
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim().ToLower();

                queryable = queryable.Where(a =>
                    a.Id.ToString().Contains(term) ||
                    a.UserName!.ToLower().Contains(term) ||
                    a.Scope.ToString().ToLower().Contains(term) ||
                    a.Role.ToString().ToLower().Contains(term) ||
                    a.Facility.Name.ToLower().Contains(term)
                );
            }

            var totalCount = await queryable.CountAsync(cancellationToken);

            var orderingColumns = new Dictionary<string, Expression<Func<ApplicationUser, object>>>
            {
                ["id"] = a => a.Id,
                ["username"] = a => a.UserName!,
                ["scope"] = a => a.Scope,
                ["role"] = a => a.Role,
                ["createdon"] = a => a.CreatedOn
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

            var items = await queryable
                .Select(a => new AccountListItemResponse(
                    a.Id,
                    a.UserName!,
                    a.IsActive,
                    a.Scope,
                    a.Role,
                    a.CreatedOn,
                    a.UpdatedOn,
                    new FacilityResponse(
                        a.Facility.Id,
                        a.Facility.Name,
                        a.Facility.Cnes,
                        a.Facility.Address.Cep,
                        a.Facility.Address.Street,
                        a.Facility.Address.Number,
                        a.Facility.Address.Complement,
                        a.Facility.Address.Neighborhood,
                        a.Facility.Address.City,
                        a.Facility.Address.State,
                        a.Facility.Contact.Email,
                        a.Facility.Contact.Phone
                    )
                ))
                .ToListAsync(cancellationToken);

            return PagedResponse<AccountListItemResponse>.SuccessPaged(
                request.PageNumber,
                request.PageSize,
                totalCount,
                items
            );
        }
    }
}
