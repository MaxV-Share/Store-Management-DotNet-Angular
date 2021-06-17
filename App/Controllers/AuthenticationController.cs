
using App.Repositories.Interface;
using App.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using App.Controllers.Base;
using App.Services.Interface;
using MaxV.Base.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Linq;
using System.Security.Claims;

namespace App.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authentication)
        {
            _authenticationService = authentication;
        }
        [HttpPost]
        [Route("Register")]
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var result = await _authenticationService.LoginAsync(request);
            if (result.StatusCode >= 400)
                return StatusCode(result.StatusCode, result.Message);
            return Ok(new { token = result.Body });
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout(string request)
        {
            await _authenticationService.LogoutAsync(request);
            return Ok();
        }

        [HttpGet("validate-token")]
        [Authorize]
        public IActionResult ValidateToken([FromHeader] string authorization)
        {
            //var token = Request.Headers[HeaderNames.Authorization];
            var result = _authenticationService.CheckToken(authorization);
            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            return Ok();
        }
    }
}
