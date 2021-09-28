using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        public readonly ILogger _logger;
        public ApiController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
