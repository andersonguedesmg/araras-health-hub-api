using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using araras_health_hub_api.Dtos.Account;
using araras_health_hub_api.Interfaces;
using araras_health_hub_api.Mappers;
using araras_health_hub_api.Models;
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
                    return BadRequest("O Destino informado não existe");
                }

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    CreatedOn = registerDto.CreatedOn,
                    UpdatedOn = registerDto.UpdatedOn,
                    IsActive = registerDto.IsActive,
                    DestinationId = registerDto.DestinationId,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var rolesResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (rolesResult.Succeeded)
                    {
                        return Ok(new NewUserDto
                        {
                            UserName = appUser.UserName,
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

            if (user == null) return Unauthorized("Usuário invalido!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Senha ou usuário incorreto!");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    CreatedOn = user.CreatedOn,
                    UpdatedOn = user.UpdatedOn,
                    IsActive = user.IsActive,
                    DestinationId = user.DestinationId,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }

        [HttpGet]
        [Route("getAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var accounts = await _userManager.Users.ToListAsync();

            // var accountsUserDto = accounts.Select(s => s.ToAccountDto());

            return Ok(accounts);
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
                return NotFound();
            }

            return Ok(account);
        }
    }
}
