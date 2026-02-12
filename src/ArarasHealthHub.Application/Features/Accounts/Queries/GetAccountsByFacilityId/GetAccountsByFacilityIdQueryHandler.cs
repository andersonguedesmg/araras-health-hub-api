using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacilityId
{
    public class GetAccountsByFacilityIdQueryHandler : IRequestHandler<GetAccountsByFacilityIdQuery, ApiResponseO<List<AccountDetailsDto>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GetAccountsByFacilityIdQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<List<AccountDetailsDto>>> Handle(GetAccountsByFacilityIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

            if (currentUser == null)
            {
                return new ApiResponseO<List<AccountDetailsDto>>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, new List<AccountDetailsDto>());
            }

            if (currentUser.Scope == UserScopeEnum.Operational && currentUser.FacilityId != request.FacilityId)
            {
                return new ApiResponseO<List<AccountDetailsDto>>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, new List<AccountDetailsDto>());
            }

            var facilityExists = await _dbContext.Facilities.AnyAsync(f => f.Id == request.FacilityId, cancellationToken);
            if (!facilityExists)
            {
                return new ApiResponseO<List<AccountDetailsDto>>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Unidade"), new List<AccountDetailsDto>());
            }

            var users = await _dbContext.Users
                                        .Where(u => u.FacilityId == request.FacilityId)
                                        .Include(u => u.Facility)
                                        .AsNoTracking()
                                        .ToListAsync(cancellationToken);

            if (!users.Any())
            {
                return new ApiResponseO<List<AccountDetailsDto>>(StatusCodes.Status200OK, ApiMessages.NoAccountsFoundForFacility(request.FacilityId), new List<AccountDetailsDto>());
            }

            var userIds = users.Select(u => u.Id).ToList();

            var userRolesLinks = await _dbContext.UserRoles
                .Where(ur => userIds.Contains(ur.UserId))
                .ToListAsync(cancellationToken);

            var roleIds = userRolesLinks.Select(ur => ur.RoleId).Distinct().ToList();
            var roles = await _dbContext.Roles
                .Where(r => roleIds.Contains(r.Id))
                .Select(r => new { r.Id, r.Name })
                .ToDictionaryAsync(r => r.Id, r => r.Name!, cancellationToken);

            var rolesLookup = userRolesLinks
                .GroupBy(ur => ur.UserId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(ur => roles[ur.RoleId]).ToList()
                );

            var accountDetailsList = new List<AccountDetailsDto>();

            foreach (var user in users)
            {
                var accountDto = _mapper.Map<AccountDetailsDto>(user);
                accountDto.Roles = rolesLookup.GetValueOrDefault(user.Id, new List<string>());
                accountDto.IsActive = user.IsActive;

                if (user.Facility != null)
                {
                    accountDto.Facility = _mapper.Map<FacilityDetailsDto>(user.Facility);
                }

                accountDetailsList.Add(accountDto);
            }

            return new ApiResponseO<List<AccountDetailsDto>>(StatusCodes.Status200OK, ApiMessages.AccountsFoundForFacility(request.FacilityId), accountDetailsList);
        }
    }
}
