using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Repositories;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Messages;
using ArarasHealthHub.Shared.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ActivateAccount
{
    public class ActivateAccountCommandHandler : IRequestHandler<ActivateAccountCommand, ApiResponse<object>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFacilityRepository _facilityRepository;

        public ActivateAccountCommandHandler(
            UserManager<ApplicationUser> userManager,
            IFacilityRepository facilityRepository)
        {
            _userManager = userManager;
            _facilityRepository = facilityRepository;
        }

        public async Task<ApiResponse<object>> Handle(
            ActivateAccountCommand request,
            CancellationToken cancellationToken)
        {
            var account = await _userManager.FindByIdAsync(request.Id.ToString());

            if (account is null)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status404NotFound,
                    ApiMessages.EntityNotFound(EntityNames.Account));
            }

            if (account.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.EntityAlreadyActive(EntityNames.Account));
            }

            var facility = await _facilityRepository
                .GetByIdAsync(account.FacilityId, cancellationToken);

            if (facility is null || !facility.IsActive)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status409Conflict,
                    ApiMessages.CannotActivateBecauseInactive(
                        EntityNames.Account,
                        EntityNames.Facility)
                );
            }

            account.Activate();

            var result = await _userManager.UpdateAsync(account);

            if (!result.Succeeded)
            {
                return ApiResponse<object>.FailureResponse(
                    StatusCodes.Status500InternalServerError,
                    ApiMessages.FailedToChangeAccountStatus);
            }

            return ApiResponse<object>.SuccessResponse(
                StatusCodes.Status200OK,
                ApiMessages.EntityActivated(EntityNames.Account));
        }
    }
}
