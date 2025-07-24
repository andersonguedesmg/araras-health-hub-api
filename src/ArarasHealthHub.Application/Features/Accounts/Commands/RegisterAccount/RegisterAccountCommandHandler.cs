using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Role.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Domain.Interfaces;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, ApiResponse<NewAccountDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IFacilityRepository _facilityRepo;
        private readonly ITokenService _tokenService;

        public RegisterAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IFacilityRepository facilityRepo,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _facilityRepo = facilityRepo;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<NewAccountDto>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var facilityExists = await _facilityRepo.FacilityExists(request.FacilityId);
            if (!facilityExists)
            {
                return new ApiResponse<NewAccountDto>(StatusCodes.Status400BadRequest, ApiMessages.MsgFacilityDoesNotExist, false);
            }

            if (await _userManager.FindByNameAsync(request.UserName) != null)
            {
                return new ApiResponse<NewAccountDto>(StatusCodes.Status400BadRequest, ApiMessages.MsgAccountNameAlreadyInUse, false);
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                FacilityId = request.FacilityId,
                IsActive = request.IsActive,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.MinValue
            };

            var createUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createUserResult.Succeeded)
            {
                var identityErrors = createUserResult.Errors.Select(e => e.Description).ToList();
                var errorsDict = new Dictionary<string, List<string>> { { "GeneralErrors", identityErrors } };
                return new ApiResponse<NewAccountDto>(StatusCodes.Status400BadRequest, ApiMessages.MsgFailedToCreateAccount, errorsDict, false);
            }

            if (!await _roleManager.RoleExistsAsync(request.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(request.Role));
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, request.Role);

            if (!addRoleResult.Succeeded)
            {
                var identityErrors = addRoleResult.Errors.Select(e => e.Description).ToList();
                var errorsDict = new Dictionary<string, List<string>> { { "GeneralErrors", identityErrors } };
                return new ApiResponse<NewAccountDto>(StatusCodes.Status500InternalServerError, ApiMessages.MsgFailedToAssignRoleToAccount, errorsDict, false);
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user.Id, user.UserName!, roles);

            var NewAccountDto = new NewAccountDto
            {
                UserId = user.Id,
                UserName = user.UserName!,
                IsActive = user.IsActive,
                FacilityId = user.FacilityId,
                Token = token,
                Roles = roles.Select(r => new RoleDto { Name = r }).ToList()
            };

            return new ApiResponse<NewAccountDto>(StatusCodes.Status201Created, ApiMessages.MsgAccountCreatedSuccessfully, NewAccountDto);
        }
    }
}
