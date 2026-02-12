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

namespace ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, ApiResponseO<AccountDetailsDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GetAccountByIdQueryHandler(UserManager<ApplicationUser> userManager, IApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ApiResponseO<AccountDetailsDto>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(u => u.Facility)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            if (user == null)
            {
                return new ApiResponseO<AccountDetailsDto>(StatusCodes.Status404NotFound, ApiMessages.NotFound("Conta"), null);
            }

            var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);
            if (currentUser == null)
            {
                return new ApiResponseO<AccountDetailsDto>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, null);
            }

            if (currentUser.Scope == UserScopeEnum.Operational)
            {
                if (user.Id != currentUser.Id && user.FacilityId != currentUser.FacilityId)
                {
                    return new ApiResponseO<AccountDetailsDto>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, null);
                }
            }

            var roles = await _userManager.GetRolesAsync(user);

            var accountDto = _mapper.Map<AccountDetailsDto>(user);
            accountDto.Roles = roles.ToList();
            accountDto.IsActive = user.IsActive;

            if (user.Facility != null)
            {
                accountDto.Facility = _mapper.Map<FacilityDetailsDto>(user.Facility);
            }

            return new ApiResponseO<AccountDetailsDto>(StatusCodes.Status200OK, ApiMessages.FoundSuccessfully("Conta"), accountDto);
        }
    }
}
