using App.Controllers.Base;
using App.DTO;
using App.Repositories.Interface;
using App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class UsersController : ApiController
    {
        public readonly IUserService _userService;
        public readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public UsersController(IUserService userService, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            //Request.Headers
            var result = await _userService.GetAllAsync("");
            return Ok(result);
        }
    }
}
