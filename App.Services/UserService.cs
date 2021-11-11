using App.Models.DTOs;
using App.Repositories.UnitOffWorks;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Services
{
    public class UserService : IUserService
    {
        public readonly IUnitOffWork _unitOffWork;
        public readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOffWork unitOffWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOffWork = unitOffWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(string filter)
        {
            var entities = await _unitOffWork.UserRepository.GetAll(filter).ToListAsync();
            var result = _mapper.Map<IEnumerable<UserViewModel>>(entities);
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
