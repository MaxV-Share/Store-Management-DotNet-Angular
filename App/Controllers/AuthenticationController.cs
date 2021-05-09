
using App.Repositories.Interface;
using App.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using App.Controllers.Base;
using App.Services.Interface;
using MaxV.Base.DTOs;

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
                var result = await _authenticationService.Register(request);
                if (result.Body)
                    return Ok();
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDTO request)
        {
            var result = await _authenticationService.Login(request);
            if (result.StatusCode >= 400)
                return StatusCode(result.StatusCode, result.Message);
            return Ok(new { token = result.Body });
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout(string request)
        {
            await _authenticationService.Logout(request);
            return Ok();
        }
    }
}
