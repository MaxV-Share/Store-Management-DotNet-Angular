using App.Controllers.Base;
using App.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class UsersController : ApiController
    {
        public readonly IUserService _userService;
        public readonly IConfiguration _configuration;
        public UsersController(IUserService userService, IConfiguration configuration, ILogger<UsersController> logger) : base(logger)
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
