using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Role.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Application.Interfaces.Services;
using ArarasHealthHub.Domain.Authorization;
using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, ApiResponse<AccountCreatedDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IFacilityRepository _facilityRepo;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IFacilityRepository facilityRepo,
            IAuthorizationService authorizationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _facilityRepo = facilityRepo;
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse<AccountCreatedDto>> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var requiredPermission = new ManageAccountRequirement(request.Scope, request.Role);
            var currentUser = _httpContextAccessor.HttpContext?.User;

            if (currentUser == null || !currentUser.Identity!.IsAuthenticated)
            {
                return new ApiResponse<AccountCreatedDto>(StatusCodes.Status401Unauthorized, ApiMessages.AuthorizationRequired, false);
            }

            var authorizationResult = await _authorizationService.AuthorizeAsync(
                currentUser, null, requiredPermission
            );

            if (!authorizationResult.Succeeded)
            {
                return new ApiResponse<AccountCreatedDto>(StatusCodes.Status403Forbidden, ApiMessages.InsufficientPermissions, false);
            }

            if (await _userManager.FindByNameAsync(request.UserName) != null)
            {
                return new ApiResponse<AccountCreatedDto>(StatusCodes.Status400BadRequest, ApiMessages.AccountNameAlreadyInUse, false);
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                FacilityId = request.FacilityId,
                Scope = request.Scope,
            };

            var createUserResult = await _userManager.CreateAsync(user, request.Password);

            if (!createUserResult.Succeeded)
            {
                var identityErrors = createUserResult.Errors.Select(e => e.Description).ToList();
                var errorsDict = new Dictionary<string, List<string>> { { "GeneralErrors", identityErrors } };
                return new ApiResponse<AccountCreatedDto>(StatusCodes.Status400BadRequest, ApiMessages.FailedToCreateAccount, errorsDict, false);
            }

            var requestedRole = request.Role.ToUpper();

            if (!await _roleManager.RoleExistsAsync(requestedRole))
            {
                await _userManager.DeleteAsync(user);
                return new ApiResponse<AccountCreatedDto>(StatusCodes.Status400BadRequest, ApiMessages.RoleDoesNotExist, false);
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, requestedRole);

            if (!addRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                var identityErrors = addRoleResult.Errors.Select(e => e.Description).ToList();
                var errorsDict = new Dictionary<string, List<string>> { { "GeneralErrors", identityErrors } };
                return new ApiResponse<AccountCreatedDto>(StatusCodes.Status500InternalServerError, ApiMessages.FailedToAssignRoleToAccount, errorsDict, false);
            }

            var createdDto = new AccountCreatedDto
            {
                UserId = user.Id,
                UserName = user.UserName!,
                Role = requestedRole,
                Scope = user.Scope,
                FacilityId = user.FacilityId
            };

            return new ApiResponse<AccountCreatedDto>(StatusCodes.Status201Created, ApiMessages.CreatedSuccessfully("Conta"), createdDto);
        }
    }
}
