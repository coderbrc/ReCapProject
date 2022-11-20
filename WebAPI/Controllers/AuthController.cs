using Business.Abstract;
using Core.Utilities.Results;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register(UserForLoginRegisterDto userForLoginRegisterDto)
        {
            var userExist = authService.UserExist(userForLoginRegisterDto.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registerUser = authService.Register(userForLoginRegisterDto, userForLoginRegisterDto.Password);
            var result = authService.CreateAccessToken(registerUser.Data);
            if (result.Success)
            {
               return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
