using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, PagedResponse<AccountDetailsDto>>
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

        public async Task<PagedResponse<AccountDetailsDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
            if (string.IsNullOrEmpty(userId))
            {
                return new PagedResponse<AccountDetailsDto>(1, 1, 0, new List<AccountDetailsDto>())
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Success = false,
                    Message = ApiMessages.AuthorizationRequired
                };
            }

            var currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser == null)
            {
                return new PagedResponse<AccountDetailsDto>(1, 1, 0, new List<AccountDetailsDto>())
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Success = false,
                    Message = ApiMessages.AuthorizationRequired
                };
            }

            IQueryable<ApplicationUser> query = _dbContext.Users
                .Include(u => u.Facility)
                .AsQueryable();

            if (currentUser.Scope == UserScopeEnum.Operational)
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
                    (!u.LockoutEnd.HasValue || u.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow).ToString().ToLower().Contains(searchTermLower) ||
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
                return new PagedResponse<AccountDetailsDto>(
                    request.PageNumber,
                    request.PageSize,
                    0,
                    new List<AccountDetailsDto>()
                );
            }

            var accountDetailsList = new List<AccountDetailsDto>();
            foreach (var user in pagedUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var accountDto = _mapper.Map<AccountDetailsDto>(user);
                accountDto.Roles = roles.ToList();
                accountDto.Scope = user.Scope;

                if (user.Facility != null)
                {
                    accountDto.Facility = _mapper.Map<FacilityDetailsDto>(user.Facility);
                }

                accountDetailsList.Add(accountDto);
            }

            return new PagedResponse<AccountDetailsDto>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                accountDetailsList
            );
        }
    }
}
