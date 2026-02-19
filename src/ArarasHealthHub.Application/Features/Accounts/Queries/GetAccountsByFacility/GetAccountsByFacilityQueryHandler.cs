using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacility
{
    public class GetAccountsByFacilityQueryHandler : IRequestHandler<GetAccountsByFacilityQuery, ApiResponse<List<GetAccountsByFacilityResponse>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountsByFacilityQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<List<GetAccountsByFacilityResponse>>> Handle(
            GetAccountsByFacilityQuery request,
            CancellationToken cancellationToken)
        {
            var facilityExists = await _context.Facilities
                .AnyAsync(f => f.Id == request.FacilityId, cancellationToken);

            if (!facilityExists)
            {
                return ApiResponse<List<GetAccountsByFacilityResponse>>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Facility));
            }

            var accounts = await _context.Set<ApplicationUser>()
                .Where(a => a.FacilityId == request.FacilityId)
                .AsNoTracking()
                .Select(a => new GetAccountsByFacilityResponse(
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
                )))
                .ToListAsync(cancellationToken);

            return ApiResponse<List<GetAccountsByFacilityResponse>>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.OperationSuccessful,
                accounts);
        }
    }
}
