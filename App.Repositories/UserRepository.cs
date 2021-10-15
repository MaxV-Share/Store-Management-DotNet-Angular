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
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IQueryable<User> GetAll(string filter)
        {
            var result = _userManager.Users.Where(e => e.UserName.Contains(filter) || e.PhoneNumber.Contains(filter));
            return result;
        }
    }
}
