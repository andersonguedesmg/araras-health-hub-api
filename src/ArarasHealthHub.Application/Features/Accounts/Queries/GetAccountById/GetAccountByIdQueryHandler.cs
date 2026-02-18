using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, ApiResponse<GetAccountByIdResponse>>
    {
        private readonly IApplicationDbContext _context;

        public GetAccountByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<GetAccountByIdResponse>> Handle(
            GetAccountByIdQuery request,
            CancellationToken cancellationToken)
        {
            var account = await _context.Set<ApplicationUser>()
                .Where(a => a.Id == request.UserId)
                .Select(a => new GetAccountByIdResponse(
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
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);

            if (account is null)
            {
                return ApiResponse<GetAccountByIdResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Account));
            }

            return ApiResponse<GetAccountByIdResponse>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.FoundSuccessfully(EntityNames.Account),
                account);
        }
    }
}
