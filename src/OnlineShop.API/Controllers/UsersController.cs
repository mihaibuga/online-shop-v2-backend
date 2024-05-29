using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using OnlineShop.Application.DTOs.Auth;
using OnlineShop.Application.DTOs.Users;

using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Interfaces.Services.Authentication;

namespace OnlineShop.API.Controllers
{
	[Route("api/users")]
	public class UsersController : ApiControllerBase
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _tokenService;

		public UsersController(UserManager<AppUser> userManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_tokenService = tokenService;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var appUser = new AppUser
				{
					UserName = userDto.Username,
					Email = userDto.Email
				};

				if (userDto.Password != null)
				{
					var result = await _userManager.CreateAsync(appUser, userDto.Password);

					if (result.Succeeded)
					{
						return Ok(
								new NewUserDto
								{
									UserName = appUser.UserName != null ? appUser.UserName : string.Empty,
									Email = appUser.Email != null ? appUser.Email : string.Empty,
									Token = _tokenService.CreateToken(appUser)
								}
							);
					}
					else
					{
						return StatusCode(500, result.Errors);
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

		[HttpGet]
		[Authorize]
		public IActionResult GetAll()
		{
			var users = _userManager.Users;
			return Ok(users);
		}

		[HttpGet("{id:Guid}")]
		[Authorize]
		public async Task<IActionResult> GetById([FromRoute] string id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingUser = await _userManager.FindByIdAsync(id);

			if (existingUser == null)
			{
				return NotFound("The user does not exist.");
			}

			return Ok(existingUser);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		[Authorize]
		public async Task<IActionResult> Delete([FromRoute] string id)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				var existingUser = await _userManager.FindByIdAsync(id);

				if (existingUser == null)
				{
					return NotFound("The user does not exist.");
				}
				else
				{
					var result = await _userManager.DeleteAsync(existingUser);

					if (result.Succeeded)
					{
						return NoContent();
					}
					else
					{
						return StatusCode(500, result.Errors);
					}
				}

			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
	}
}
