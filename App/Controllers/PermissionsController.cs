using App.Controllers.Base;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class PermissionsController : ApiController
    {
        public PermissionsController(ILogger<PermissionsController> logger) : base(logger)
        {
        }
    }
}
