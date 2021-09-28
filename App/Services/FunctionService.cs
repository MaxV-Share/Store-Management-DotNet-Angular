using App.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.DTOs.CreateRequests;
using App.Services.Interface;
using App.Infrastructures.UnitOffWorks;
using App.Repositories.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using App.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using MaxV.Helper;
using System.Threading;
using MySql.Data;

namespace App.Services
{
    public class FunctionService : BaseService<Function, FunctionCreateRequest, FunctionUpdateRequest, FunctionViewModel, string>, IFunctionService
    {
        public FunctionService( IMapper mapper, IUnitOffWork unitOffWork, ILogger<FunctionService> logger) : base(mapper, unitOffWork, logger)
        {
        }
        public override async Task<IEnumerable<FunctionViewModel>> GetAllDTOAsync()
        {
            var entities = await _unitOffWork.FunctionRepository.GetNoTrackingEntities().OrderBy(e => e.ParentId).ThenBy(e => e.SortOrder).ToListAsync();
            var functions = _mapper.Map<List<FunctionViewModel>>(entities);
            return functions;
        }
        public async Task<IEnumerable<FunctionViewModel>> GetTreeAsync()
        {
            var entities = await _unitOffWork.FunctionRepository.GetNoTrackingEntities().Include(e => e.Childrens).Where(e => e.ParentId == null).OrderBy(e => e.ParentId).ThenBy(e => e.SortOrder).ToListAsync();
            var result = _mapper.Map<List<FunctionViewModel>>(entities);
            return result;
        }
        public async Task<IEnumerable<TreeFunctionViewModel>> GetTreeNodeAsync()
        {
            var entities = await _unitOffWork.FunctionRepository.GetNoTrackingEntities().OrderBy(e => e.ParentId).ThenBy(e => e.SortOrder).ToListAsync();
            var functions = _mapper.Map<List<FunctionViewModel>>(entities);
            var result = functions.ToNodeChildTree(null);
            return result;
        }
        public async Task<IEnumerable<FunctionViewModel>> GetFunctionsWithoutChildren(string textSearch)
        {
            var entities = await _unitOffWork.FunctionRepository.GetNoTrackingEntities().Where(e => e.ParentId == null && EF.Functions.Like(e.Name,$"%{textSearch}%")).OrderBy(e => e.SortOrder).ThenBy(e => e.Name).ToListAsync();
            var result = _mapper.Map<List<FunctionViewModel>>(entities);
            return result;
        }
    }
}
