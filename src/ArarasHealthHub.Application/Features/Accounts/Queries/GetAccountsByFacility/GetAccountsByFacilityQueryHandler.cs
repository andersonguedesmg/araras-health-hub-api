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

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacility
{
    public class GetAccountsByFacilityQueryHandler : IRequestHandler<GetAccountsByFacilityQuery, Result<List<AccountResponse>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountsByFacilityQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<AccountResponse>>> Handle(
            GetAccountsByFacilityQuery request,
            CancellationToken cancellationToken)
        {
            var facilityExists = await _context.Facilities
                .AnyAsync(f => f.Id == request.FacilityId, cancellationToken);

            if (!facilityExists)
                throw new NotFoundException("Facility não encontrada.");

            var accounts = await _context.Set<ApplicationUser>()
                .Where(a => a.FacilityId == request.FacilityId)
                .AsNoTracking()
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
                .ToListAsync(cancellationToken);

            return Result<List<AccountResponse>>.Success(accounts);
        }
    }
}
