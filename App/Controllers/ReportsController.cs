using App.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class ReportsController : ApiController
    {
        public ReportsController(ILogger<ReportsController> logger) : base(logger)
        {

        }
    }
}
