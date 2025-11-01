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

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacilityId
{
    public class GetAccountsByFacilityIdQueryHandler : IRequestHandler<GetAccountsByFacilityIdQuery, ApiResponse<List<AccountDetailsDto>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAccountsByFacilityIdQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<List<AccountDetailsDto>>> Handle(GetAccountsByFacilityIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

            if (currentUser == null)
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, new List<AccountDetailsDto>());
            }

            if (currentUser.Scope == UserScopeEnum.Operational && currentUser.FacilityId != request.FacilityId)
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, new List<AccountDetailsDto>());
            }

            var facility = await _dbContext.Facilities.FirstOrDefaultAsync(f => f.Id == request.FacilityId, cancellationToken);
            if (facility == null)
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Unidade"), new List<AccountDetailsDto>());
            }

            var users = await _dbContext.Users
                                        .Where(u => u.FacilityId == request.FacilityId)
                                        .Include(u => u.Facility)
                                        .ToListAsync(cancellationToken);

            if (!users.Any())
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status200OK, ApiMessages.NoAccountsFoundForFacility(request.FacilityId), new List<AccountDetailsDto>());
            }

            var accountDetailsList = new List<AccountDetailsDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var isUserActive = !user.LockoutEnd.HasValue || user.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow;

                var accountDto = new AccountDetailsDto
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    IsActive = isUserActive,
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

                accountDetailsList.Add(accountDto);
            }

            return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status200OK, ApiMessages.AccountsFoundForFacility(request.FacilityId), accountDetailsList);
        }
    }
}
