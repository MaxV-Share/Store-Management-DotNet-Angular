using App.Controllers.Base;
using App.DTO;
using App.Services.Interface;
using MaxV.Base.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authentication, ILogger<AuthenticationController> logger) : base(logger)
        {
            _authenticationService = authentication;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDTO request)
        {
            try
            {
                var result = await _authenticationService.RegisterAsync(request);
                if (result.Body)
                    return Ok();
                return BadRequest(result.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var result = await _authenticationService.LoginAsync(request);
            if (result.StatusCode >= 400)
                return StatusCode(result.StatusCode, result.Message);
            return Ok(new { token = result.Body });
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout(string request)
        {
            await _authenticationService.LogoutAsync(request);
            return Ok();
        }

        [HttpGet("validate-token")]
        //[Authorize]
        public async Task<IActionResult> ValidateToken([FromHeader] string authorization)
        {
            var result = await _authenticationService.CheckToken(authorization);
            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            return Ok(result);
        }
    }
}
