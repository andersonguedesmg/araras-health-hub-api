using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, PagedResponse<AccountDetailsDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllAccountsQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext, IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PagedResponse<AccountDetailsDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationUser> query = _dbContext.Users
                                                .Include(u => u.Facility)
                                                .AsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);

            switch (request.OrderBy.ToLower())
            {
                case "username":
                    query = request.SortOrder.ToLower() == "desc" ?
                            query.OrderByDescending(u => u.UserName) :
                            query.OrderBy(u => u.UserName);
                    break;
                case "createdon":
                    query = request.SortOrder.ToLower() == "desc" ?
                            query.OrderByDescending(u => u.CreatedOn) :
                            query.OrderBy(u => u.CreatedOn);
                    break;
                case "isactive":
                    query = request.SortOrder.ToLower() == "desc" ?
                            query.OrderByDescending(u => u.IsActive) :
                            query.OrderBy(u => u.IsActive);
                    break;
                case "id":
                default:
                    query = request.SortOrder.ToLower() == "desc" ?
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
