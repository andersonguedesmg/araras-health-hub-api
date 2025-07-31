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

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacilityId
{
    public class GetAccountsByFacilityIdQueryHandler : IRequestHandler<GetAccountsByFacilityIdQuery, ApiResponse<List<AccountDetailsDto>>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;

        public GetAccountsByFacilityIdQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<List<AccountDetailsDto>>> Handle(GetAccountsByFacilityIdQuery request, CancellationToken cancellationToken)
        {
            var facility = await _dbContext.Facilities.FirstOrDefaultAsync(f => f.Id == request.FacilityId, cancellationToken);
            if (facility == null)
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status404NotFound, ApiMessages.MsgFacilityNotFound, new List<AccountDetailsDto>());
            }

            var users = await _dbContext.Users
                                        .Where(u => u.FacilityId == request.FacilityId)
                                        .Include(u => u.Facility)
                                        .ToListAsync(cancellationToken);

            if (!users.Any())
            {
                return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status200OK, $"Nenhuma conta encontrada para a Facility com ID {request.FacilityId}.", new List<AccountDetailsDto>());
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

            return new ApiResponse<List<AccountDetailsDto>>(StatusCodes.Status200OK, $"Contas da Facility com ID {request.FacilityId} recuperadas com sucesso.", accountDetailsList);
        }
    }
}
