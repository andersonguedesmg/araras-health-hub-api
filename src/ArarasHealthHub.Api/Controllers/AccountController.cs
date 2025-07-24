
using System.Net;
using ArarasHealthHub.Application.Features.Accounts.Commands.ChangeStatusAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword;
using ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacilityId;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Shared.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    // [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Master,Admin")]
        [ProducesResponseType(typeof(ApiResponse<NewAccountDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ApiResponse<NewAccountDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<NewAccountDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var command = new RegisterAccountCommand
            {
                UserName = request.UserName!,
                Password = request.Password!,
                FacilityId = request.FacilityId,
                Role = request.Role,
                IsActive = request.IsActive
            };

            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<NewAccountDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<NewAccountDto>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<NewAccountDto>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var command = new LoginAccountCommand { UserName = request.UserName, Password = request.Password };
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("resetPassword")]
        [Authorize(Roles = "Master,Admin")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            var command = new ResetPasswordCommand(request.UserName, request.NewPassword);
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllAccounts()
        {
            var query = new GetAllAccountsQuery();
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAccountById(int userId)
        {
            var query = new GetAccountByIdQuery(userId);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getByFacilityId/{facilityId:int}")]
        [Authorize(Roles = "Admin,Manager,User")]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<List<AccountDetailsDto>>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> GetAccountsByFacilityId(int facilityId)
        {
            var query = new GetAccountsByFacilityIdQuery { FacilityId = facilityId };
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("update")]
        [Authorize(Roles = "Master,Admin")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDto request)
        {
            var command = new UpdateAccountCommand(
                request.UserId,
                request.UserName
            );

            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("changeStatus/{id}")]
        [Authorize(Roles = "Master,Admin")]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> ChangeStatus([FromRoute] int id, [FromBody] ChangeStatusAccountCommand command)
        {
            if (id != command.UserId)
            {
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.MsgIdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }
    }
}
