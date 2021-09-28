using App.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class PermissionsController : ApiController
    {
        public PermissionsController(ILogger<PermissionsController> logger) : base(logger)
        {
        }
    }
}
