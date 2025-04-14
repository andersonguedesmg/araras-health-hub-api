using araras_health_hub_api.Data;
using araras_health_hub_api.Dtos.Account;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Models;
using araras_health_hub_api.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace araras_health_hub_api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IDestinationRepository _destinationRepo;
        private readonly ApplicationDBContext _dbContext;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IDestinationRepository destinationRepo, ApplicationDBContext dbContext)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _destinationRepo = destinationRepo;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, ModelState));

            if (!await _destinationRepo.DestinationExists(registerDto.DestinationId))
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.MsgDestinationDoesNotExist, null!));

            var appUser = new AppUser
            {
                UserName = registerDto.UserName,
                CreatedOn = registerDto.CreatedOn,
                UpdatedOn = registerDto.UpdatedOn,
                IsActive = registerDto.IsActive,
                DestinationId = registerDto.DestinationId,
            };

            var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);

            if (!createdUser.Succeeded)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.MsgAccountCreationFailed, createdUser.Errors));

            var rolesResult = await _userManager.AddToRoleAsync(appUser, registerDto.Role);

            if (!rolesResult.Succeeded)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.MsgRoleAssignmentFailed, rolesResult.Errors));

            var newUserDto = new NewUserDto
            {
                UserName = appUser.UserName!,
                CreatedOn = appUser.CreatedOn,
                UpdatedOn = appUser.UpdatedOn,
                IsActive = appUser.IsActive,
                DestinationId = appUser.DestinationId,
            };

            return CreatedAtAction(nameof(Register), new ApiResponse<NewUserDto>(StatusCodes.Status201Created, ApiMessages.MsgAccountCreatedSuccessfully, newUserDto));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<AppUser>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null)
                return Unauthorized(new ApiResponse<AppUser>(StatusCodes.Status401Unauthorized, ApiMessages.MsgAccountUnauthorized, null!));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized(new ApiResponse<AppUser>(StatusCodes.Status401Unauthorized, ApiMessages.MsgAccountIncorrect, null!));

            var account = new NewUserDto
            {
                UserName = user.UserName!,
                UserId = user.Id!,
                CreatedOn = user.CreatedOn,
                UpdatedOn = user.UpdatedOn,
                IsActive = user.IsActive,
                DestinationId = user.DestinationId,
                Token = _tokenService.CreateToken(user)
            };

            return Ok(new ApiResponse<NewUserDto>(StatusCodes.Status200OK, ApiMessages.MsgAccountLoginSuccessful, account));
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<AppUser>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var accounts = await _userManager.Users.Include(u => u.Destination).ToListAsync();

            var usersWithRoles = await _userManager.Users.Include(u => u.Destination)
                .Select(user => new AccountWithRolesDto
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    NormalizedUserName = user.NormalizedUserName!,
                    CreatedOn = user.CreatedOn,
                    UpdatedOn = user.UpdatedOn,
                    IsActive = user.IsActive,
                    DestinationId = user.DestinationId,
                    Destination = user.Destination!,
                    Roles = _dbContext.UserRoles
                        .Where(ur => ur.UserId == user.Id)
                        .Join(_dbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => new RoleDto { Id = r.Id, Name = r.Name! })
                        .ToList()
                })
                .ToListAsync();

            return Ok(new ApiResponse<List<AccountWithRolesDto>>(StatusCodes.Status200OK, ApiMessages.MsgAccountsFoundSuccessfully, usersWithRoles));
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<AppUser>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var account = await _userManager.Users.Include(u => u.Destination).FirstOrDefaultAsync(x => x.Id == id);

            if (account == null)
            {
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));
            }

            var userRoles = await _dbContext.UserRoles
                .Where(ur => ur.UserId == id)
                .Join(_dbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => new { RoleId = r.Id, RoleName = r.Name })
                .ToListAsync();

            var response = new
            {
                User = account,
                Roles = userRoles
            };

            return Ok(new ApiResponse<object>(StatusCodes.Status200OK, ApiMessages.MsgAccountFoundSuccessfully, response));
        }

        [HttpGet]
        [Route("getByDestinationId/{destinationId:int}")]
        [Authorize]
        public async Task<IActionResult> GetByDestinationId([FromRoute] int destinationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<List<AppUser>>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, null!));

            var accounts = await _userManager.Users
                .Where(u => u.DestinationId == destinationId)
                .ToListAsync();

            if (accounts == null || accounts.Count == 0)
            {
                return NotFound(new ApiResponse<List<AppUser>>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));
            }

            var userRoles = await _dbContext.UserRoles
                .Where(ur => accounts.Select(a => a.Id).Contains(ur.UserId))
                .Join(_dbContext.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => new { ur.UserId, RoleId = r.Id, RoleName = r.Name })
                .ToListAsync();

            var response = accounts.Select(account => new
            {
                account.Id,
                account.UserName,
                account.CreatedOn,
                account.UpdatedOn,
                account.IsActive,
                account.DestinationId,
                Roles = userRoles.Where(ur => ur.UserId == account.Id).Select(ur => new { ur.RoleId, ur.RoleName }).ToList()
            }).ToList();

            return Ok(new ApiResponse<object>(StatusCodes.Status200OK, ApiMessages.MsgAccountFoundSuccessfully, response));
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserNameDto updateUserNameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, ModelState));

            var user = await _userManager.FindByIdAsync(updateUserNameDto.Id.ToString());

            if (user == null)
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));

            user.UserName = updateUserNameDto.UserName;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.MsgAccountUpdatedSuccessfully, result.Errors));

            return Ok(new ApiResponse<AppUser>(StatusCodes.Status200OK, ApiMessages.MsgAccountUpdatedSuccessfully, user));
        }

        [HttpPut]
        [Route("changeStatus")]
        [Authorize]
        public async Task<IActionResult> ChangeStatus([FromBody] UpdateUserNameDto updateUserNameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.Msg400BadRequestError, ModelState));

            var user = await _userManager.FindByIdAsync(updateUserNameDto.Id.ToString());

            if (user == null)
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));

            user.IsActive = updateUserNameDto.IsActive;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(new ApiResponse<object>(StatusCodes.Status400BadRequest, ApiMessages.MsgAccountUpdatedSuccessfully, result.Errors));

            if (updateUserNameDto.IsActive == true)
            {
                return Ok(new ApiResponse<AppUser>(StatusCodes.Status200OK, ApiMessages.MsgAccountActivatedSuccessfully, user));
            }

            return Ok(new ApiResponse<AppUser>(StatusCodes.Status200OK, ApiMessages.MsgAccountDisabledSuccessfully, user));
        }
    }
}
