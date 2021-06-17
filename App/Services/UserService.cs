using App.DTO;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
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
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllAsync(string filter)
        {
            var entities = await _userRepository.GetAllAsync(filter);
            var result = _mapper.Map<IEnumerable<UserViewModel>>(entities);
            return result;
        }

        public async Task<UserViewModel> GetUserById(string id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            var result = _mapper.Map<UserViewModel>(entity);
            return result;
        }
    }
}
