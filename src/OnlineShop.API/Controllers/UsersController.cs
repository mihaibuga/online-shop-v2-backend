using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.DTOs.Auth;
using OnlineShop.Application.DTOs.Users;
using OnlineShop.Application.Helpers.QueryObjects;
using OnlineShop.Application.Wrappers;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Interfaces.Services.Authentication;
using System.Security.Claims;


namespace OnlineShop.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ITokenService _tokenService;

        public UsersController(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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

                //Check if email is already used
                AppUser existingUserByEmail = await _userManager.FindByEmailAsync(userDto.Email);

                if (existingUserByEmail != null)
                {
                    return BadRequest(new { message = "This email is already associated with an existing account." });
                }

                //Check if username is already used
                AppUser? existingUserByUserName = await _userManager.FindByNameAsync(userDto.Username);

                if (existingUserByUserName != null)
                {
                    return BadRequest(new { message = "This username is already used." });
                }

                AppUser appUser = new AppUser
                {
                    UserName = userDto.Username,
                    Email = userDto.Email
                };

                if (userDto.Password != null)
                {
                    IdentityResult result = await _userManager.CreateAsync(appUser, userDto.Password);

                    if (result.Succeeded)
                    {
                        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                        {
                            await _roleManager.CreateAsync(new AppRole { Name = UserRoles.User });
                        }
                        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                        {
                            await _roleManager.CreateAsync(new AppRole { Name = UserRoles.Admin });
                        }

                        var chosenRole = UserRoles.User;
                        if (!String.IsNullOrEmpty(userDto.Role))
                        {
                            // Assign chosen role value as capitalized
                            chosenRole = userDto.Role.ToLower().First().ToString().ToUpper() + userDto.Role.ToLower().Substring(1);
                        }

                        if (await _roleManager.RoleExistsAsync(UserRoles.User))
                        {
                            //Associate user to role
                            IdentityResult roleResult = await _userManager.AddToRoleAsync(appUser, UserRoles.User);

                            if (roleResult.Succeeded)
                            {
                                return Ok(
                                new NewUserDto
                                {
                                    UserName = appUser.UserName != null ? appUser.UserName : string.Empty,
                                    Email = appUser.Email != null ? appUser.Email : string.Empty,
                                    Token = await _tokenService.CreateToken(appUser)
                                }
                                );
                            }

                            return StatusCode(500, roleResult.Errors);
                        }

                        return StatusCode(500, "An internal problem has occured! Please try again later!");
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
        public async Task<IActionResult> GetAll([FromQuery] UserQueryObject query)
        {
            var users = _userManager.Users.AsQueryable();

            //Sort users
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("username", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsAscending ? users.OrderBy(u => u.UserName) : users.OrderByDescending(u => u.UserName);
                }
                else if (query.SortBy.Equals("email", StringComparison.OrdinalIgnoreCase))
                {
                    users = query.IsAscending ? users.OrderBy(u => u.Email) : users.OrderByDescending(u => u.Email);
                }
                else
                {
                    users = users.OrderBy(u => u.UserName);
                }
            }

            //Paginate users
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var pagedUsers = users.Skip(skipNumber).Take(query.PageSize);

            //Create paginated response
            var response = new PagedResponse<IQueryable<AppUser>>(pagedUsers, query.PageNumber, query.PageSize);

            var totalUsers = await _userManager.Users.CountAsync();
            response.TotalRecords = totalUsers;

            var totalPages = ((double)totalUsers / (double)query.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.TotalPages = roundedTotalPages;

            response.IsNextPage = response.PageNumber >= 1 && response.PageNumber < roundedTotalPages;
            response.IsPreviousPage = response.PageNumber - 1 >= 1 && response.PageNumber <= roundedTotalPages;

            return Ok(response);
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
