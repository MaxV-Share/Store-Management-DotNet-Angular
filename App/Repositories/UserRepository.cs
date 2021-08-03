using App.Models.Entities;
using App.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities.Identities;

namespace App.Repositories.Interface
{

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public readonly IMapper _mapper;
        public UserRepository(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAllAsync(string filter)
        {
            var result = await  _userManager.Users
                                            .Where(e =>(e.UserName.Contains(filter) || e.PhoneNumber.Contains(filter)))
                                            .ToListAsync();
            return result;
        }
    }
}
