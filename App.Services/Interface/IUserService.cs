using App.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserUpdateRequest>> GetAllAsync(string filter);
        Task<UserUpdateRequest> GetUserById(string id);
        Task<UserUpdateRequest> GetCurrentUser();
    }
}
