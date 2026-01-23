using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Facilities.Dtos;
using ArarasHealthHub.Application.Interfaces.Contexts;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Facilities.Queries.GetFacilityProfile
{
    public class GetFacilityProfileQueryHandler : IRequestHandler<GetFacilityProfileQuery, ApiResponse<FacilityProfileDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GetFacilityProfileQueryHandler(
            UserManager<ApplicationUser> userManager,
            IApplicationDbContext dbContext,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FacilityProfileDto>> Handle(GetFacilityProfileQuery request, CancellationToken cancellationToken)
        {
            // var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

            // if (currentUser == null)
            // {
            //     return new ApiResponse<FacilityProfileDto>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, false);
            // }

            // var facilityId = currentUser.FacilityId;
            // var facility = await _dbContext.Facilities
            //     .AsNoTracking()
            //     .FirstOrDefaultAsync(f => f.Id == facilityId, cancellationToken);

            // if (facility == null)
            // {
            //     return new ApiResponse<FacilityProfileDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Unidade"), null!);
            // }

            // var users = await _dbContext.Users
            //     .AsNoTracking()
            //     .Where(u => u.FacilityId == facilityId)
            //     .ToListAsync(cancellationToken);

            // var profileDto = _mapper.Map<FacilityProfileDto>(facility);

            // var accountDetailsList = new List<AccountDetailsDto>();
            // foreach (var user in users)
            // {
            //     var roles = await _userManager.GetRolesAsync(user);

            //     var isUserActive = !user.LockoutEnd.HasValue || user.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow;

            //     accountDetailsList.Add(new AccountDetailsDto
            //     {
            //         UserId = user.Id,
            //         UserName = user.UserName!,
            //         IsActive = user.IsActive,
            //         Scope = user.Scope,
            //         Roles = roles.ToList()
            //     });
            // }

            // profileDto.FacilityAccounts = accountDetailsList;
            return null!;
            // return new ApiResponse<FacilityProfileDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Perfil da Unidade"), profileDto);
        }
    }
}
