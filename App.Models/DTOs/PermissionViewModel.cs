using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class PermissionViewModel : BaseViewModel<Guid>
    {
        public string FunctionId { get; set; }
        public string RoleId { get; set; }
        public string CommandId { get; set; }
    }
}
