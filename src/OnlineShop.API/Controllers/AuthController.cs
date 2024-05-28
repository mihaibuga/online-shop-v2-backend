using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Interfaces.Services.Authentication;

using OnlineShop.Application.DTOs.Auth;

namespace OnlineShop.API.Controllers
{
	[Route("api/auth")]
	public class AuthController : ApiControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signinManager;
		private readonly ITokenService _tokenService;

		public AuthController(
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
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var appUser = new AppUser
				{
					UserName = registerDto.Username,
					Email = registerDto.Email
				};

				if (registerDto.Password != null)
				{
					var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

					if (createdUser.Succeeded)
					{
						var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

						if (roleResult.Succeeded)
						{
							return Ok(
								new NewUserDto
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
				else
				{
					return StatusCode(500, "An internal problem has occured! Please try again later!");
				}
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto loginDTO)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var user = loginDTO.Username != null
				? await _userManager
				.Users
				.FirstOrDefaultAsync(
					x => x.UserName == loginDTO.Username.ToLower()
				)
				: null;

			if (user == null)
			{
				return Unauthorized("Invalid username!");
			}

			if (loginDTO.Password != null)
			{
				var result = await _signinManager
					.CheckPasswordSignInAsync(user, loginDTO.Password, false);

				if (!result.Succeeded)
				{
					return Unauthorized("Username not found and/or password incorrect");
				}

				return Ok(
					new NewUserDto
					{
						UserName = user.UserName,
						Email = user.Email,
						Token = _tokenService.CreateToken(user)
					}
				);
			}
			else
			{
				return Unauthorized("Username not found and/or password incorrect");
			}
		}
	}
}