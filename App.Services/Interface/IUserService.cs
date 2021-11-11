using App.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllAsync(string filter);
        Task<UserViewModel> GetUserById(string id);
        Task<UserViewModel> GetCurrentUser();
    }
}
