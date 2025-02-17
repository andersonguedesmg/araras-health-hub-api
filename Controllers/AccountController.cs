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

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IDestinationRepository destinationRepo)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _destinationRepo = destinationRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (!await _destinationRepo.DestinationExists(registerDto.DestinationId))
                {
                    return BadRequest(new ApiResponse<AppUser>(StatusCodes.Status400BadRequest, ApiMessages.MsgDestinationDoesNotExist, null!));
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    CreatedOn = registerDto.CreatedOn,
                    UpdatedOn = registerDto.UpdatedOn,
                    IsActive = registerDto.IsActive,
                    DestinationId = registerDto.DestinationId,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password!);

                if (createdUser.Succeeded)
                {
                    var rolesResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (rolesResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            UserName = appUser.UserName!,
                            CreatedOn = appUser.CreatedOn,
                            UpdatedOn = appUser.UpdatedOn,
                            IsActive = appUser.IsActive,
                            DestinationId = appUser.DestinationId,
                            Token = _tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, rolesResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null)
                return Unauthorized(new ApiResponse<AppUser>(StatusCodes.Status401Unauthorized, ApiMessages.MsgAccountUnauthorized, null!));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized(new ApiResponse<AppUser>(StatusCodes.Status401Unauthorized, ApiMessages.MsgAccountIncorrect, null!));

            var account = new NewUserDto
            {
                UserName = user.UserName!,
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
                return BadRequest(ModelState);

            var accounts = await _userManager.Users.ToListAsync();

            return Ok(new ApiResponse<List<AppUser>>(StatusCodes.Status200OK, ApiMessages.MsgUsersFoundSuccessfully, accounts));
        }

        [HttpGet]
        [Route("getByUserName/{userName}")]
        [Authorize]
        public async Task<IActionResult> GetByUserName([FromRoute] string userName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName.ToLower());

            if (account == null)
            {
                return NotFound(new ApiResponse<AppUser>(StatusCodes.Status404NotFound, ApiMessages.MsgAccountNotFound, null!));
            }

            return Ok(new ApiResponse<AppUser>(StatusCodes.Status200OK, ApiMessages.MsgAccountFoundSuccessfully, account));
        }
    }
}
