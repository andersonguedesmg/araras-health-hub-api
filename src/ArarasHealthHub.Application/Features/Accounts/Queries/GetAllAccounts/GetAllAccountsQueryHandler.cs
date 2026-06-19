using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, PagedResult<AccountListItemResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAccountsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<AccountListItemResponse>> Handle(
            GetAllAccountsQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Set<ApplicationUser>()
                .AsNoTracking()
                .AsQueryable();

            if (request.IsActive.HasValue)
            {
                query = query.Where(s => s.IsActive == request.IsActive.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.Trim();

                query = query.Where(s =>
                    EF.Functions.Like(s.UserName, $"%{term}%"));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            query = request.OrderBy?.ToLower() switch
            {
                "username" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.UserName)
                    : query.OrderBy(x => x.UserName),

                "scope" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Scope)
                    : query.OrderBy(x => x.Scope),

                "role" => request.SortOrder == "desc"
                    ? query.OrderByDescending(x => x.Role)
                    : query.OrderBy(x => x.Role),

                _ => query.OrderBy(x => x.UserName)
            };

            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
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
                        new AddressResponse(
                            a.Facility.Address.Street,
                            a.Facility.Address.Number,
                            a.Facility.Address.Complement,
                            a.Facility.Address.Neighborhood,
                            a.Facility.Address.City,
                            a.Facility.Address.State,
                            a.Facility.Address.Cep
                        ),
                        new ContactResponse(
                            a.Facility.Contact.Email,
                            a.Facility.Contact.Phone
                        ),
                        a.CreatedOn,
                        a.UpdatedOn,
                        a.IsActive
                    )
                ))
                .ToListAsync(cancellationToken);

            return PagedResult<AccountListItemResponse>.Success(
                items,
                request.PageNumber,
                request.PageSize,
                totalCount,
                "Contas listadas com sucesso.");
        }
    }
}
