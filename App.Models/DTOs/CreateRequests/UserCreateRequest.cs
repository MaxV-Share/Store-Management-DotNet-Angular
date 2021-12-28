using App.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class UserCreateRequest : BaseCreateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
