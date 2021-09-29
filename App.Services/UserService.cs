using App.DTO;
using App.Repositories.UnitOffWorks;
using App.Models.Entities;
using App.Models.Entities.Identities;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<UserUpdateRequest>> GetAllAsync(string filter)
        {
            var entities = await _unitOffWork.UserRepository.GetAllAsync(filter);
            var result = _mapper.Map<IEnumerable<UserUpdateRequest>>(entities);
            return result;
        }

        public async Task<UserUpdateRequest> GetUserById(string id)
        {
            var entity = await _unitOffWork.UserManager.FindByIdAsync(id);
            var result = _mapper.Map<UserUpdateRequest>(entity);
            return result;
        }
        public async Task<UserUpdateRequest> GetCurrentUser()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(claim => claim.Type == ClaimTypes.Name)?.Value;
            if (userName == null)
            {
                return null;
            }
            var user = await _unitOffWork.UserManager.FindByNameAsync(userName);
            var result = _mapper.Map<UserUpdateRequest>(user);

            return result;
        }
    }
}
