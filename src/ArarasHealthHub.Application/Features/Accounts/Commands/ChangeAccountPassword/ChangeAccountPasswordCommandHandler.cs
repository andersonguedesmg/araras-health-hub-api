using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Domain.Enums;
using ArarasHealthHub.Domain.Identity;
using ArarasHealthHub.Shared.Exceptions;
using ArarasHealthHub.Shared.Results;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ArarasHealthHub.Application.Features.Accounts.Commands.ChangeAccountPassword
{
    public class ChangeAccountPasswordCommandHandler : IRequestHandler<ChangeAccountPasswordCommand, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChangeAccountPasswordCommandHandler(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result> Handle(
            ChangeAccountPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var targetUser = await _userManager.FindByIdAsync(request.TargetUserId.ToString());

            if (targetUser is null)
                throw new NotFoundException("Conta não encontrada.");

            var userPrincipal = _httpContextAccessor.HttpContext?.User;

            if (userPrincipal is null)
                throw new UnauthorizedAccessException("Usuário não autenticado.");

            var roleClaim = userPrincipal.FindFirst(ClaimTypes.Role)?.Value;
            var facilityClaim = userPrincipal.FindFirst("facilityId")?.Value;

            if (roleClaim is null)
                throw new UnauthorizedAccessException("Claim de role não encontrada.");

            var currentRole = Enum.Parse<AccountRoleEnum>(roleClaim);

            if (currentRole == AccountRoleEnum.User)
                throw new ForbiddenException("Você não tem permissão para alterar senhas.");

            if (currentRole == AccountRoleEnum.Admin)
            {
                if (facilityClaim is null)
                    throw new UnauthorizedAccessException("FacilityId não encontrado.");

                var currentFacilityId = int.Parse(facilityClaim);

                if (targetUser.FacilityId != currentFacilityId)
                    throw new ForbiddenException("Você não tem permissão para alterar a senha deste usuário.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(targetUser);

            var result = await _userManager.ResetPasswordAsync(
                targetUser,
                token,
                request.NewPassword
            );

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));

                throw new BusinessRuleException($"Falha ao redefinir senha: {errors}");
            }

            return Result.Success("Senha alterada com sucesso.");
        }
    }
}
