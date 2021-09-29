using App.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ReportsController : ApiController
    {
        public ReportsController(ILogger<ReportsController> logger) : base(logger)
        {

        }
    }
}
