using MaxV.Base.DTOs;
using System;

namespace App.Models.DTOs
{
    public class PermissionViewModel : BaseViewModel<Guid>
    {
        public string FunctionId { get; set; }
        public string RoleId { get; set; }
        public string CommandId { get; set; }
    }
}
