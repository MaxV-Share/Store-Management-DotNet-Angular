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
        Task<Response<bool>> Register(RegisterDTO request);
        Task<Response<string>> Login(LoginDTO request);
        Task Logout(string request);
        Task<string> CheckToken(string authorization);
    }
}
