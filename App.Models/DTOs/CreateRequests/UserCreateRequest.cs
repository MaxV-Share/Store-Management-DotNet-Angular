using MaxV.Base.DTOs;

namespace App.DTO
{
    public class UserCreateRequest : BaseCreateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
