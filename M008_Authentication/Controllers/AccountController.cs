using M008_Authentication.Data;
using M008_Authentication.Models;
using M008_Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace M008_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email,
            };

            try
            {
                var userResult = await _userManager.CreateAsync(user, model.Password);
                if (userResult.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, AuthDemoDbContext.USER_ROLE);
                    if (roleResult.Succeeded)
                    {
                        return Ok(new UserResultDto
                        {
                            UserName = model.Username,
                            Email = model.Email,
                            Token = _tokenService.CreateToken(user)
                        });
                    }
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, userResult.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return Ok(new UserResultDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                });
            }

            return Unauthorized("Username not found or password incorrect!");
        }

    }
}
