using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, ApiResponse<List<AccountDetailsDto>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;

        public GetAllAccountsQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<List<AccountDetailsDto>>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                                        .Include(u => u.Facility)
                                        .ToListAsync(cancellationToken);

            if (!users.Any())
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status200OK, ApiMessages.MsgNotAccountsFound, new List<AccountDetailsDto>());
            }

            var accountDetailsList = new List<AccountDetailsDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                var accountDto = new AccountDetailsDto
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    IsActive = user.IsActive,
                    CreatedOn = user.CreatedOn,
                    UpdatedOn = user.UpdatedOn,
                    Roles = roles.ToList()
                };

                if (user.Facility != null)
                {
                    accountDto.Facility = new FacilityDetailsDto
                    {
                        Id = user.Facility.Id,
                        Name = user.Facility.Name,
                        Address = user.Facility.Address,
                        Number = user.Facility.Number,
                        Neighborhood = user.Facility.Neighborhood,
                        Cep = user.Facility.Cep,
                        Email = user.Facility.Email,
                        Phone = user.Facility.Phone
                    };
                }

                accountDetailsList.Add(accountDto);
            }

            return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status200OK, ApiMessages.MsgAccountsFoundSuccessfully, accountDetailsList);
        }
    }
}
