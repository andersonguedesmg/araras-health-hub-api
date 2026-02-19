using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, ApiResponse<AccountCreatedResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFacilityRepository _facilityRepository;

        public CreateAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            IFacilityRepository facilityRepository)
        {
            _userManager = userManager;
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<AccountCreatedResponse>> Handle(
            CreateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser is not null)
            {
                return ApiResponse<AccountCreatedResponse>.FailureResponse(
                    StatusCodes.Status400BadRequest,
                    ApiMessages.AccountNameAlreadyInUse);
            }

            var facility = await _facilityRepository
                .GetByIdAsync(request.FacilityId, cancellationToken);

            if (facility is null)
            {
                return ApiResponse<AccountCreatedResponse>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Facility));
            }

            if (!facility.IsActive)
            {
                return ApiResponse<AccountCreatedResponse>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.CannotActivateBecauseInactive(
                        EntityNames.Account,
                        EntityNames.Facility)
                );
            }

            var user = new ApplicationUser(
                request.UserName,
                request.FacilityId,
                request.Scope,
                request.Role,
                request.IsActive);

            var createResult = await _userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                var errors = createResult.Errors
                    .GroupBy(e => e.Code)
                    .ToDictionary(
                        g => g.Key,
                        g => (IReadOnlyList<string>)g.Select(e => e.Description).ToList()
                    );

                return ApiResponse<AccountCreatedResponse>.FailureResponse(
                    StatusCodes.Status400BadRequest,
                    ApiMessages.FailedToCreateAccount,
                    errors);
            }

            var response = new AccountCreatedResponse(
                user.Id,
                user.UserName!,
                user.Role,
                user.Scope,
                user.FacilityId,
                user.IsActive);

            return ApiResponse<AccountCreatedResponse>.SuccessResponse(
                StatusCodes.Status201Created,
                ApiMessages.EntityCreated(EntityNames.Account),
                response);
        }
    }
}
