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

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, ApiResponse<AccountDetailsDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;

        public GetAccountByIdQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
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

            return new ApiResponse<AccountDetailsDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Conta"), accountDto);
        }
    }
}
