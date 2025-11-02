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
    public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, ApiResponse<LoginResponseDto>>
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

        public async Task<ApiResponse<LoginResponseDto>> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);

            if (user == null)
            {
                return new ApiResponse<LoginResponseDto>(StatusCodes.Status401Unauthorized, ApiMessages.AccountIncorrect, false);
            }

            var isUserActive = !user.LockoutEnd.HasValue || user.LockoutEnd.Value.ToUniversalTime() < DateTime.UtcNow;

            if (!isUserActive)
            {
                return new ApiResponse<LoginResponseDto>(StatusCodes.Status403Forbidden, ApiMessages.AccountDisabled, false);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                return new ApiResponse<LoginResponseDto>(StatusCodes.Status401Unauthorized, ApiMessages.AccountIncorrect, false);
            }

            var roles = await _userManager.GetRolesAsync(user);

            var roleDtos = _roleManager.Roles
                .Where(r => roles.Contains(r.Name!))
                .Select(r => new UserRoleDto { Id = r.Id, Name = r.Name! })
                .ToList();

            var token = _tokenService.CreateToken(user.Id, user.UserName!, roles, user.Scope);

            var responseDto = new LoginResponseDto
            {
                UserId = user.Id,
                UserName = user.UserName!,
                IsActive = isUserActive,
                FacilityId = user.FacilityId,
                Token = token,
                Scope = user.Scope,
                Roles = roleDtos
            };

            return new ApiResponse<LoginResponseDto>(StatusCodes.Status200OK, ApiMessages.AccountLoginSuccessful, responseDto);
        }
    }
}
