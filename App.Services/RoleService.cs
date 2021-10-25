using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities.Identities;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        public RoleService(ILogger<RoleService> logger, RoleManager<Role> roleManager, IMapper mapper)
        {
            _logger = logger;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<RoleViewModel> GetByIdAsync(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);
            return _mapper.Map<RoleViewModel>(entity);
        }

        public async Task<int> DeleteHardAsync(string id)
        {
            var entity = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(entity);
            return 1;
        }

        public Task<int> DeleteSoftAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(string id, RoleUpdateRequest request)
        {
            var entity = await _roleManager.FindByIdAsync(id);
            _mapper.Map(request, entity);
            var result = await _roleManager.UpdateAsync(entity);
            if (result.Succeeded)
                return 1;
            return 0;
        }

        public async Task<RoleViewModel> CreateAsync(RoleCreateRequest request)
        {
            var entity = new Role();
            _mapper.Map(request, entity);
            var result = await _roleManager.CreateAsync(entity);
            if (result.Succeeded)
                return _mapper.Map<RoleViewModel>(entity);
            return null;
        }

        public Task<IEnumerable<RoleViewModel>> CreateAsync(IEnumerable<RoleCreateRequest> request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleViewModel>> GetAllDTOAsync()
        {
            var entities = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleViewModel>>(entities);
        }
    }
}
