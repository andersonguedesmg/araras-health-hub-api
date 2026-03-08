using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Common.Responses;
using ArarasHealthHub.Application.Features.Facilities.Responses;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityProfile
{
    public class GetFacilityProfileQueryHandler : IRequestHandler<GetFacilityProfileQuery, Result<FacilityProfileResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetFacilityProfileQueryHandler(
            IApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Result<FacilityProfileResponse>> Handle(
            GetFacilityProfileQuery request,
            CancellationToken cancellationToken)
        {
            var currentUser =
                await _userManager.GetUserAsync(
                    _httpContextAccessor.HttpContext!.User);

            if (currentUser is null)
                throw new UnauthorizedException();

            var facilityId = currentUser.FacilityId;

            var facility =
                await _context.Facilities
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                        f => f.Id == facilityId,
                        cancellationToken);

            if (facility is null)
                throw new NotFoundException("Unidade não encontrada.");

            var accounts =
                await _context.ApplicationUsers
                    .AsNoTracking()
                    .Where(u => u.FacilityId == facilityId)
                    .Select(u => new FacilityAccountResponse(
                        u.Id,
                        u.UserName!,
                        u.IsActive,
                        u.Scope,
                        u.Role,
                        u.CreatedOn,
                        u.UpdatedOn
                    ))
                    .ToListAsync(cancellationToken);

            var response = new FacilityProfileResponse(
                facility.Id,
                facility.Name,
                facility.Cnes,
                new AddressResponse(
                    facility.Address.Cep,
                    facility.Address.Street,
                    facility.Address.Number,
                    facility.Address.Neighborhood,
                    facility.Address.City,
                    facility.Address.State,
                    facility.Address.Complement!
                ),
                new ContactResponse(
                    facility.Contact.Email,
                    facility.Contact.Phone
                ),
                facility.CreatedOn,
                facility.UpdatedOn,
                facility.IsActive,
                accounts
            );

            return Result<FacilityProfileResponse>.Success(response);
        }
    }
}
