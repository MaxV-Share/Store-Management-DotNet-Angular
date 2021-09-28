using App.DTO;
using MaxV.Base.DTOs;
using MaxV.Helper.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
