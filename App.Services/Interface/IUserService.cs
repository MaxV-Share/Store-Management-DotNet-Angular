using App.Common.Model;
using App.Common.Model.DTOs;
using App.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IUserService
    {
        Task<IBasePaging<UserViewModel>> GetAllAsync(IFilterBodyRequest request);
        Task<UserViewModel> GetUserById(string id);
        Task<UserViewModel> GetCurrentUser();
    }
}
