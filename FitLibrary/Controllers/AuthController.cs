using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using FitLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitLibrary.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService userService, ITokenService authService)
        {
            _authService = userService;
            _tokenService = authService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterPL registerUser)
        {
            var user = new UserBLL
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                Password = registerUser.Password
            };

            try
            {
                await _authService.RegisterAsync(user);
                
                var token = _tokenService.GenerateToken(user);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }

            return StatusCode(500, ModelState);
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginPL loginUser)
        {
            var user = new UserBLL
            {
                Email = loginUser.Email,
                Password = loginUser.Password
            };

            try
            {
                await _authService.LoginAsync(user);
                var token = _tokenService.GenerateToken(user);

                return Ok(new { token });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Model", ex.Message);
            }

            return StatusCode(500, ModelState);
        }
    }
}
