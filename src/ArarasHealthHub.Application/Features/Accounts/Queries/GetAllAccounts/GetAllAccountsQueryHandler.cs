using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;

using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, PagedResponseO<AccountDetailsDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllAccountsQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedResponseO<AccountDetailsDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var userIdString = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out _))
            {
                return new PagedResponseO<AccountDetailsDto>(1, 1, 0, new List<AccountDetailsDto>())
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Success = false,
                    Message = ApiMessages.AuthorizationRequired
                };
            }

            var currentUser = await _userManager.FindByIdAsync(userIdString);
            if (currentUser == null)
            {
                return new PagedResponseO<AccountDetailsDto>(1, 1, 0, new List<AccountDetailsDto>())
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Success = false,
                    Message = ApiMessages.AuthorizationRequired
                };
            }

            IQueryable<ApplicationUser> query = _dbContext.Users
                .Include(u => u.Facility)
                .AsNoTracking()
                .AsQueryable();

            if (currentUser.Scope == AccountScopeEnum.Operational)
            {
                query = query.Where(u => u.FacilityId == currentUser.FacilityId);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTermLower = request.SearchTerm.ToLower();

                query = query.Where(u =>
                    u.Id.ToString().Contains(searchTermLower) ||
                    u.UserName!.ToLower().Contains(searchTermLower) ||
                    u.FacilityId.ToString().Contains(searchTermLower) ||
                    (u.Facility != null && u.Facility.Name.ToLower().Contains(searchTermLower)) ||
                    u.Scope.ToString().ToLower().Contains(searchTermLower)
                );
            }

            var totalCount = await query.CountAsync(cancellationToken);

            switch (request.OrderBy.ToLower())
            {
                case "username":
                    query = request.SortOrder?.ToLower() == "desc" ?
                                query.OrderByDescending(u => u.UserName) :
                                query.OrderBy(u => u.UserName);
                    break;
                case "id":
                default:
                    query = request.SortOrder?.ToLower() == "desc" ?
                                query.OrderByDescending(u => u.Id) :
                                query.OrderBy(u => u.Id);
                    break;
            }

            var pagedUsers = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            if (!pagedUsers.Any())
            {
                return new PagedResponseO<AccountDetailsDto>(
                    request.PageNumber,
                    request.PageSize,
                    0,
                    new List<AccountDetailsDto>()
                );
            }

            var userIds = pagedUsers.Select(u => u.Id).ToList();

            var userRolesLinks = await _dbContext.UserRoles
                .Where(ur => userIds.Contains(ur.UserId))
                .ToListAsync(cancellationToken);

            var roleIds = userRolesLinks.Select(ur => ur.RoleId).Distinct().ToList();
            var roles = await _dbContext.Roles
                .Where(r => roleIds.Contains(r.Id))
                .Select(r => r.Name!)
                .ToListAsync(cancellationToken);

            var rolesLookup = userRolesLinks
                .Join(_dbContext.Roles,
                      ur => ur.RoleId,
                      r => r.Id,
                      (ur, r) => new { ur.UserId, RoleName = r.Name! })
                .GroupBy(a => a.UserId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(a => a.RoleName).ToList()
                );

            var accountDetailsList = new List<AccountDetailsDto>();
            foreach (var user in pagedUsers)
            {
                var accountDto = _mapper.Map<AccountDetailsDto>(user);
                accountDto.Roles = rolesLookup.GetValueOrDefault(user.Id, new List<string>());
                accountDto.Scope = user.Scope;

                if (user.Facility != null)
                {
                    accountDto.Facility = _mapper.Map<FacilityDetailsDto>(user.Facility);
                }

                accountDetailsList.Add(accountDto);
            }

            return new PagedResponseO<AccountDetailsDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                accountDetailsList
            );
        }
    }
}
