using System.Net;
using System.Text;

using araras_health_hub_api.Common;
using araras_health_hub_api.Filters;

using ArarasHealthHub.Application.Features.Accounts.Commands.ActivateAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.ChangeAccountPassword;
using ArarasHealthHub.Application.Features.Accounts.Commands.CreateAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.DeactivateAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacility;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Shared.Pagination;
using ArarasHealthHub.Shared.Responses;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/v1/accounts")]
    [ApiController]
    [Authorize]
    public class AccountController : BaseApiController
    {
        [HttpPost]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(ApiResponse<AccountCreatedResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command, cancellationToken);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<LoginAccountResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command, cancellationToken);
        }

        [HttpPatch("{id:int}/change-password")]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangeAccountPasswordCommand command, CancellationToken cancellationToken)
        {
            return await Send(command with { TargetUserId = id }, cancellationToken);
        }

        [HttpGet]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(PagedResponse<AccountListItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAccountsQuery query, CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("{id:int}")]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(ApiResponse<GetAccountByIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<GetAccountByIdResponse>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return await Send(new GetAccountByIdQuery(id), cancellationToken);
        }

        [HttpGet("facility/{facilityId:int}")]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(ApiResponse<List<GetAccountsByFacilityResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<List<GetAccountsByFacilityResponse>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountsByFacility(int facilityId, CancellationToken cancellationToken)
        {
            return await Send(new GetAccountsByFacilityQuery(facilityId), cancellationToken);
        }

        [HttpPut("{id:int}")]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command.WithId(id), cancellationToken);
        }

        [HttpPatch("{id:int}/activate")]
        [AuthorizeAccountManagement]
        public async Task<IActionResult> Activate(int id, ActivateAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command.WithId(id), cancellationToken);
        }

        [HttpPatch("{id:int}/deactivate")]
        [AuthorizeAccountManagement]
        public async Task<IActionResult> Deactivate(int id, DeactivateAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command.WithId(id), cancellationToken);
        }
    }
}
