using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Result<AccountResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<AccountResponse>> Handle(
            GetAccountByIdQuery request,
            CancellationToken cancellationToken)
        {
            var account = await _context.Set<ApplicationUser>()
                .Where(a => a.Id == request.UserId)
                .Select(a => new AccountResponse(
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
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (account is null)
                throw new NotFoundException("Conta não encontrada.");

            return Result<AccountResponse>.Success(account);
        }
    }
}
