using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Interfaces.Services.Authentication;

using OnlineShop.Application.DTOs.Auth;

namespace OnlineShop.API.Controllers
{
    [Route("api/auth")]
    public class UserController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signinManager;
		private readonly ITokenService _tokenService;

		public UserController(
			UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager,
			ITokenService tokenService
		)
		{
			_userManager = userManager;
			_signinManager = signInManager;
			_tokenService = tokenService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var appUser = new AppUser
				{
					UserName = registerDTO.Username,
					Email = registerDTO.Email
				};

				var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

				if (createdUser.Succeeded)
				{
					var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

					if (roleResult.Succeeded)
					{
						return Ok(
							new NewUserDTO
							{
								UserName = appUser.UserName,
								Email = appUser.Email,
								Token = _tokenService.CreateToken(appUser)
							}
						);
					}
					else
					{
						return StatusCode(500, roleResult.Errors);
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
		public async Task<IActionResult> Login(LoginDTO loginDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var user = await _userManager
				.Users
				.FirstOrDefaultAsync(
					x => x.UserName == loginDTO.Username.ToLower()
				);

			if (user == null)
			{
				return Unauthorized("Invalid username!");
			}

			var result = await _signinManager
				.CheckPasswordSignInAsync(user, loginDTO.Password, false);

			if (!result.Succeeded)
			{
				return Unauthorized("Username not found and/or password incorrect");
			}

			return Ok(
				new NewUserDTO
				{
					UserName = user.UserName,
					Email = user.Email,
					Token = _tokenService.CreateToken(user)
				}
			);
		}
	}
}