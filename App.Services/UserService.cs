using App.Common.Extensions;
using App.Common.Model;
using App.Common.Model.DTOs;
using App.EFCore;
using App.Models.DTOs;
using App.Repositories.UnitOffWorks;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOffWork _unitOffWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOffWork unitOffWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOffWork = unitOffWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IBasePaging<UserViewModel>> GetAllAsync(IFilterBodyRequest request)
        {
            var query = _mapper.ProjectTo<UserViewModel>(_unitOffWork.UserManager.Users);

            if (!request.SearchValue.IsNullOrEmpty())
            {
                query = query.Where(e => EF.Functions.Like(e.PhoneNumber, $"%{request.SearchValue}%") || EF.Functions.Like(e.UserName, $"%{request.SearchValue}%"));
            }

            var result = await query.ToPagingAsync(request);
            return result;
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            var entity = await _unitOffWork.UserManager.FindByIdAsync(id);
            var result = _mapper.Map<UserViewModel>(entity);
            return result;
        }
        public async Task<UserViewModel> GetCurrentUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(claim => claim.Type == ClaimTypes.Name)?.Value;
            if (userName == null)
            {
                return null;
            }
            var user = await _unitOffWork.UserManager.FindByNameAsync(userName);
            var result = _mapper.Map<UserViewModel>(user);

            return result;
        }
    }
}
