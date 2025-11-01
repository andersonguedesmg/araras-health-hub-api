using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.ExportAccounts
{
    public class ExportAccountsQueryHandler : IRequestHandler<ExportAccountsQuery, IEnumerable<AccountDetailsDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExportAccountsQueryHandler(
            UserManager<ApplicationUser> userManager,
            IApplicationDbContext dbContext,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<AccountDetailsDto>> Handle(ExportAccountsQuery request, CancellationToken cancellationToken)
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext!.User);
            if (string.IsNullOrEmpty(userId))
            {
                return Enumerable.Empty<AccountDetailsDto>();
            }

            var currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser == null)
            {
                return Enumerable.Empty<AccountDetailsDto>();
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
                    u.Scope.ToString().ToLower().Contains(searchTermLower)
                );
            }

            var allFilteredUsers = await query
                                        .OrderBy(u => u.Id)
                                        .ToListAsync(cancellationToken);

            if (!allFilteredUsers.Any())
            {
                return Enumerable.Empty<AccountDetailsDto>();
            }

            var accountDetailsList = new List<AccountDetailsDto>();
            foreach (var user in allFilteredUsers)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var isUserActive = !user.LockoutEnd.HasValue || user.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow;

                var accountDto = _mapper.Map<AccountDetailsDto>(user);

                accountDto.Roles = roles.ToList();
                accountDto.Scope = user.Scope;
                accountDto.IsActive = isUserActive;

                accountDetailsList.Add(accountDto);
            }

            return accountDetailsList;
        }
    }
}
