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
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacility;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Application.Features.Accounts.Responses;
using ArarasHealthHub.Shared.Results;

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
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            return await SendCreated(
                command,
                nameof(GetById),
                id => new { id },
                cancellationToken);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<LoginAccountResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command, cancellationToken);
        }

        [HttpPatch("{id:int}/change-password")]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangeAccountPasswordCommand command, CancellationToken cancellationToken)
        {
            var result = await Send(command with { TargetUserId = id }, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(PagedResult<AccountListItemResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAccountsQuery query, CancellationToken cancellationToken)
        {
            return await Send(query, cancellationToken);
        }

        [HttpGet("{id:int}")]
        [Authorize(Policy = "CanReadManagementResource")]
        [ProducesResponseType(typeof(Result<AccountResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return await Send(new GetAccountByIdQuery(id), cancellationToken);
        }

        [HttpGet("by-facility/{facilityId:int}")]
        [AuthorizeAccountManagement]
        [ProducesResponseType(typeof(Result<List<AccountResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<List<AccountResponse>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAccountsByFacility(int facilityId, CancellationToken cancellationToken)
        {
            return await Send(new GetAccountsByFacilityQuery(facilityId), cancellationToken);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Update(int id, UpdateAccountCommand command, CancellationToken cancellationToken)
        {
            return await Send(command.WithId(id), cancellationToken);
        }

        [HttpPatch("{id:int}/activate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Activate(int id, CancellationToken cancellationToken)
        {
            return await Send(new ActivateAccountCommand(id), cancellationToken);
        }

        [HttpPatch("{id:int}/deactivate")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Deactivate(int id, CancellationToken cancellationToken)
        {
            return await Send(new DeactivateAccountCommand(id), cancellationToken);
        }
    }
}
