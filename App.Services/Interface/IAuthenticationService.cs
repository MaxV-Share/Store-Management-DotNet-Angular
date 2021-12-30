using App.Models.DTOs;
using System.Threading.Tasks;
using App.Common.Model.DTOs;
using App.Common.Model;

namespace App.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<bool>> RegisterAsync(RegisterDTO request);
        Task<BaseResponse<string>> LoginAsync(LoginDTO request);
        Task LogoutAsync(string request);
        Task<string> CheckToken(string authorization);
    }
}
