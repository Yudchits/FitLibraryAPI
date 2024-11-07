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
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IRoleService _roleService;

        public AuthController(IAuthService authService, ITokenService tokenService, IRoleService roleService)
        {
            _authService = authService;
            _tokenService = tokenService;
            _roleService = roleService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterPL registerUser)
        {
            var userBLL = new UserBLL
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email
            };

            Result<UserBLL> registerResult = await _authService.RegisterAsync(userBLL, registerUser.Password);

            if (!registerResult.Success)
            {
                return Unauthorized(new { registerResult.Message });
            }

            var token = _tokenService.GenerateToken(registerResult.Data, new string[] { UserRoles.TRAINEE });

            return Ok(new { Token = token });
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginPL loginUser)
        {
            var user = new UserBLL
            {
                Email = loginUser.Email,
                Password = loginUser.Password
            };

            Result<UserBLL> loginResult = await _authService.LoginAsync(user, loginUser.Password);

            if (!loginResult.Success)
            {
                return Unauthorized(new { loginResult.Message });
            }

            var roles = await _roleService.GetUserRolesAsync(loginResult.Data);

            if (roles.Count == 0)
            {
                return Unauthorized(new { Message = "Отсутствуют какие-либо пользовательские роли. Обратитесь к администратору" });
            }

            var token = _tokenService.GenerateToken(loginResult.Data, roles);

            return Ok(new { Token = token });
        }
    }
}
