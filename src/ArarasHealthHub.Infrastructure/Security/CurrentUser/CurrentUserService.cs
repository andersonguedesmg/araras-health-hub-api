using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using ArarasHealthHub.Application.Interfaces.Security.CurrentUser;

using Microsoft.AspNetCore.Http;

namespace ArarasHealthHub.Infrastructure.Security.CurrentUser
{
    public sealed class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetAccountId()
        {
            var value =
                _httpContextAccessor.HttpContext?
                    .User
                    .FindFirst(ClaimTypes.NameIdentifier)
                    ?.Value;

            if (!int.TryParse(value, out var accountId))
            {
                throw new UnauthorizedAccessException(
                    "Usuário não autenticado."
                );
            }

            return accountId;
        }

        public int? GetFacilityId()
        {
            var value =
                _httpContextAccessor.HttpContext?
                    .User
                    .FindFirst("facility_id")
                    ?.Value;

            if (!int.TryParse(value, out var facilityId))
            {
                return null;
            }

            return facilityId;
        }

        public string? GetUserName()
        {
            return _httpContextAccessor.HttpContext?
                .User
                .Identity
                ?.Name;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?
                .User
                .Identity
                ?.IsAuthenticated == true;
        }
    }
}
