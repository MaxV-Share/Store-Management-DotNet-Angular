using App.DTO;
using MaxV.Base.DTOs;
using MaxV.Helper.Entities;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IAuthenticationService
    {
        Task<Response<bool>> RegisterAsync(RegisterDTO request);
        Task<Response<string>> LoginAsync(LoginDTO request);
        Task LogoutAsync(string request);
        Task<string> CheckToken(string authorization);
    }
}
