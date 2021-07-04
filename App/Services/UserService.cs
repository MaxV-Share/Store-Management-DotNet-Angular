using App.DTO;
using App.Models.Entities;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(string filter)
        {
            var entities = await _userRepository.GetAllAsync(filter);
            var result = _mapper.Map<IEnumerable<UserViewModel>>(entities);
            return result;
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);
            var result = _mapper.Map<UserViewModel>(entity);
            return result;
        }
    }
}
