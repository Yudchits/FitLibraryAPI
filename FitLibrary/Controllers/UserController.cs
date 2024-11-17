using FitLibrary.DataAccess.Common.Helpers;
using FitLibrary.Logic.Common.Models;
using FitLibrary.Logic.Common.Services;
using FitLibrary.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitLibrary.WebAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterPL registerUser)
        {
            var userBLL = new UserBLL
            {
                FirstName = registerUser.FirstName,
                MiddleName = registerUser.MiddleName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                Password = registerUser.Password
            };

            Result<UserBLL> registerResult = await _userService.CreateAsync(userBLL);

            if (!registerResult.Success)
            {
                return StatusCode(400, new { Message = registerResult.Message });
            }

            var token = _tokenService.GenerateToken(registerResult.Data);

            return Ok(new { Token = token });
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginPL loginUser)
        {
            var user = new UserBLL
            {
                Email = loginUser.Email,
                Password = loginUser.Password
            };

            Result<UserBLL> loginResult = await _userService.CheckPasswordAsync(user);

            if (!loginResult.Success)
            {
                return StatusCode(401, new { Message = loginResult.Message });
            }

            var token = _tokenService.GenerateToken(loginResult.Data);

            return Ok(new { Token = token });
        }
    }
}
