using App.Models.DTOs;
using System.Threading.Tasks;
using MaxV.Common.Model.DTOs;
using MaxV.Common.Model;

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
