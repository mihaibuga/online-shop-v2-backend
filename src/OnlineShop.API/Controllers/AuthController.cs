using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.DTOs.Auth;
using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Interfaces.Services.Authentication;

namespace OnlineShop.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService
        )
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //Check if email is already used
                AppUser existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.Email);

                if (existingUserByEmail != null)
                {
                    return BadRequest(new { message = "This email is already associated with an existing account." });
                }

                //Check if username is already used
                AppUser? existingUserByUserName = await _userManager.FindByNameAsync(registerDto.Username);

                if (existingUserByUserName != null)
                {
                    return BadRequest(new { message = "This username is already used." });
                }

                AppUser appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                if (registerDto.Password != null)
                {
                    IdentityResult createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                    if (createdUser.Succeeded)
                    {
                        //Associate user to role
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(appUser, UserRoles.User);

                        if (roleResult.Succeeded)
                        {
                            return Ok(
                                new NewUserDto
                                {
                                    UserName = appUser.UserName,
                                    Email = appUser.Email,
                                    Token = await _tokenService.CreateToken(appUser)
                                }
                            );
                        }

                        return StatusCode(500, roleResult.Errors);
                    }

                    return StatusCode(500, createdUser.Errors);
                }

                return StatusCode(500, "An internal problem has occured! Please try again later!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //Check if email is already used
                AppUser existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.Email);

                if (existingUserByEmail != null)
                {
                    return BadRequest(new { message = "This email is already associated with an existing account." });
                }

                //Check if username is already used
                AppUser? existingUserByUserName = await _userManager.FindByNameAsync(registerDto.Username);

                if (existingUserByUserName != null)
                {
                    return BadRequest(new { message = "This username is already used." });
                }

                AppUser appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                if (registerDto.Password != null)
                {
                    IdentityResult createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                    if (createdUser.Succeeded)
                    {
                        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                        {
                            IdentityResult roleResult = await _userManager.AddToRoleAsync(appUser, UserRoles.Admin);

                            if (roleResult.Succeeded)
                            {
                                return Ok(
                                    new NewUserDto
                                    {
                                        UserName = appUser.UserName,
                                        Email = appUser.Email,
                                        Token = await _tokenService.CreateToken(appUser)
                                    }
                                );
                            }

                            return StatusCode(500, roleResult.Errors);
                        }
                    }

                    return StatusCode(500, createdUser.Errors);
                }

                return StatusCode(500, "An internal problem has occured! Please try again later!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //Check if username is already used
                AppUser? existingUser = await _userManager.FindByNameAsync(loginDTO.Username);

                if (existingUser == null)
                {
                    return Unauthorized(new { message = "Username not found and/or password incorrect" });
                }
                else
                {
                    if (loginDTO.Password != null)
                    {
                        var result = await _signinManager
                            .CheckPasswordSignInAsync(existingUser, loginDTO.Password, false);

                        if (result.Succeeded)
                        {
                            return Ok(
                                new
                                {
                                    UserName = existingUser.UserName != null ? existingUser.UserName : string.Empty,
                                    Email = existingUser.Email != null ? existingUser.Email : string.Empty,
                                    Token = await _tokenService.CreateToken(existingUser)
                                }
                            );
                        }
                        return Unauthorized(new { message = "Username not found and/or password incorrect" });
                    }

                    return Unauthorized(new { message = "Username not found and/or password incorrect" });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleAuth([FromBody] GoogleAuthDto googleUserDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //Check if google email is already used
                AppUser? existingUserByGmail = await _userManager.FindByEmailAsync(googleUserDto.Email);

                if (existingUserByGmail != null)
                {
                    return Ok(
                            new NewUserDto
                            {
                                UserName = existingUserByGmail.UserName != null ? existingUserByGmail.UserName : string.Empty,
                                Email = existingUserByGmail.Email != null ? existingUserByGmail.Email : string.Empty,
                                Token = await _tokenService.CreateToken(existingUserByGmail)
                            }
                        );
                }
                else
                {
                    //Check if username is already used
                    AppUser? existingUserByUserName = await _userManager.FindByNameAsync(googleUserDto.Username);
                    if (existingUserByUserName != null)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = existingUserByUserName.UserName != null ? existingUserByUserName.UserName : string.Empty,
                                Email = existingUserByUserName.Email != null ? existingUserByUserName.Email : string.Empty,
                                Token = await _tokenService.CreateToken(existingUserByUserName)
                            }
                        );
                    }

                    AppUser? appUser = new AppUser
                    {
                        UserName = googleUserDto.Username,
                        Email = googleUserDto.Email
                    };

                    IdentityResult? createdUser = await _userManager.CreateAsync(appUser);

                    if (createdUser.Succeeded)
                    {
                        //Associate user to role
                        IdentityResult? roleResult = await _userManager.AddToRoleAsync(appUser, UserRoles.User);

                        if (roleResult.Succeeded)
                        {
                            return Ok(
                                new NewUserDto
                                {
                                    UserName = appUser.UserName,
                                    Email = appUser.Email,
                                    Token = await _tokenService.CreateToken(appUser)
                                }
                            );
                        }

                        return StatusCode(500, roleResult.Errors);
                    }

                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}