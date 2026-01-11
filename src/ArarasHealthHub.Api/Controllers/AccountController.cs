using System.Net;
using System.Text;
using araras_health_hub_api.Filters;
using ArarasHealthHub.Application.Features.Accounts.Commands.ChangeStatusAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.LoginAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.RegisterAccount;
using ArarasHealthHub.Application.Features.Accounts.Commands.ResetPassword;
using ArarasHealthHub.Application.Features.Accounts.Commands.UpdateAccount;
using ArarasHealthHub.Application.Features.Accounts.Dtos;
using ArarasHealthHub.Application.Features.Accounts.Queries.ExportAccounts;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountById;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAccountsByFacilityId;
using ArarasHealthHub.Application.Features.Accounts.Queries.GetAllAccounts;
using ArarasHealthHub.Shared.Core.Messages;
using ArarasHealthHub.Shared.Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArarasHealthHub.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        [AuthorizeAccountManagement(typeof(RegisterRequestDto))]
        [ProducesResponseType(typeof(ApiResponse<AccountCreatedDto>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ApiResponse<AccountCreatedDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<AccountCreatedDto>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var command = new RegisterAccountCommand
            {
                UserName = request.UserName!,
                Password = request.Password!,
                FacilityId = request.FacilityId,
                Scope = request.Scope,
                Role = request.Role,
                IsActive = request.IsActive
            };

            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<LoginResponseDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<LoginResponseDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<LoginResponseDto>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<LoginResponseDto>), (int)HttpStatusCode.Forbidden)]
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
        [ProducesResponseType(typeof(PagedResponse<AccountDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAccountsQuery query)
        {
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getById/{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<AccountDetailsDto>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var query = new GetAccountByIdQuery(id);
            var result = await _mediator.Send(query);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("getByFacilityId/{facilityId:int}")]
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
        [AuthorizeAccountManagement(typeof(UpdateAccountCommand))]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountCommand command)
        {
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
                return BadRequest(new ApiResponse<bool>(StatusCodes.Status400BadRequest, ApiMessages.IdMismatch, false));
            }
            var result = await _mediator.Send(command);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("export")]
        [Authorize(Policy = "CanManageResource")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Export([FromQuery] string? searchTerm)
        {
            var accountDtos = await _mediator.Send(new ExportAccountsQuery { SearchTerm = searchTerm });
            if (accountDtos == null || !accountDtos.Any())
            {
                return NotFound(new ApiResponse<object>(StatusCodes.Status404NotFound, ApiMessages.ExportEmpty("conta"), null!));
            }

            var sb = new StringBuilder();
            sb.AppendLine("NOME, UNIDADE, FUNÇÃO, ESCOPO, STATUS");

            foreach (var accountDto in accountDtos)
            {
                var role = accountDto.Roles?.FirstOrDefault() ?? "";
                var facilityName = accountDto.Facility?.Name ?? "N/A";
                var scope = accountDto.Scope.ToString();
                var status = accountDto.IsActive ? "Ativo" : "Inativo";

                sb.Append($"{accountDto.UserName}, {facilityName}, {role}, {scope}, {status}\r\n");
            }

            var fileName = $"contas_{DateTime.Now:yyyyMMddHHmmss}.csv";

            var utf8WithBom = new UTF8Encoding(true);
            var fileBytes = utf8WithBom.GetBytes(sb.ToString());

            return File(fileBytes, "text/csv", fileName);
        }
    }
}
