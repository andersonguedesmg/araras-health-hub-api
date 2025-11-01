using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Role.Dtos;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount
{
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, ApiResponse<NewAccountDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ITokenService _tokenService;

        public LoginAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<int>> roleManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<NewAccountDto>> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);

            if (user == null)
            {
                return new ApiResponse<NewAccountDto>(StatusCodes.Status401Unauthorized, ApiMessages.AccountIncorrect, false);
            }

            var isUserActive = !user.LockoutEnd.HasValue || user.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow;

            if (!isUserActive)
            {
                return new ApiResponse<NewAccountDto>(StatusCodes.Status403Forbidden, ApiMessages.AccountDisabled, false);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                return new ApiResponse<NewAccountDto>(StatusCodes.Status401Unauthorized, ApiMessages.AccountIncorrect, false);
            }

            var roles = await _userManager.GetRolesAsync(user);

            var roleDtos = new List<RoleDto>();
            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    roleDtos.Add(new RoleDto { Id = role.Id, Name = role.Name! });
                }
            }

            var token = _tokenService.CreateToken(user.Id, user.UserName!, roles, user.Scope);

            var NewAccountDto = new NewAccountDto
            {
                UserId = user.Id,
                UserName = user.UserName!,
                IsActive = isUserActive,
                FacilityId = user.FacilityId,
                Token = token,
                Scope = user.Scope,
                Roles = roleDtos
            };

            return new ApiResponse<NewAccountDto>(StatusCodes.Status200OK, ApiMessages.AccountLoginSuccessful, NewAccountDto);
        }
    }
}
