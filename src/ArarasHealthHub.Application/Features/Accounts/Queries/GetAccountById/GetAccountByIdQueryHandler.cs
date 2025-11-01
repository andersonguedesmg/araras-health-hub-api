using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, ApiResponse<AccountDetailsDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAccountByIdQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<AccountDetailsDto>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                                        .Include(u => u.Facility)
                                        .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
            {
                return new ApiResponse<AccountDetailsDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), null);
            }

            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
            if (currentUser == null)
            {
                return new ApiResponse<AccountDetailsDto>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, null);
            }

            if (currentUser.Scope == UserScopeEnum.Operational)
            {
                if (user.Id != currentUser.Id && user.FacilityId != currentUser.FacilityId)
                {
                    return new ApiResponse<AccountDetailsDto>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, null);
                }
            }

            var roles = await _userManager.GetRolesAsync(user);

            var accountDto = new AccountDetailsDto
            {
                UserId = user.Id,
                UserName = user.UserName!,
                IsActive = !user.LockoutEnd.HasValue || user.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow,
                Scope = user.Scope,
                Roles = roles.ToList()
            };

            if (user.Facility != null)
            {
                accountDto.Facility = new FacilityDetailsDto
                {
                    Id = user.Facility.Id,
                    Name = user.Facility.Name,
                    Address = user.Facility.Address.Street,
                    Number = user.Facility.Address.Number,
                    Neighborhood = user.Facility.Address.Neighborhood,
                    Cep = user.Facility.Address.Cep,
                    Email = user.Facility.Contact.Email,
                    Phone = user.Facility.Contact.Phone
                };
            }

            return new ApiResponse<AccountDetailsDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Conta"), accountDto);
        }
    }
}
