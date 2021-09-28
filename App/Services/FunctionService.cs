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
        public FunctionService(IFunctionRepository repository, IMapper mapper, IUnitOffWork unitOffWork, ILogger<FunctionService> logger) : base(repository, mapper, unitOffWork, logger)
        {
        }
        public override async Task<IEnumerable<FunctionViewModel>> GetAllDTOAsync()
        {
            var entities = await _repository.GetNoTrackingEntities().OrderBy(e => e.ParentId).ThenBy(e => e.SortOrder).ToListAsync();
            var functions = _mapper.Map<List<FunctionViewModel>>(entities);
            return functions;
        }
        public async Task<IEnumerable<TreeFunctionViewModel>> GetTreeAsync()
        {
            var entities = await _repository.GetNoTrackingEntities().OrderBy(e => e.ParentId).ThenBy(e => e.SortOrder).ToListAsync();
            var functions = _mapper.Map<List<FunctionViewModel>>(entities);
            var result = getChildTree(functions);
            return result;
        }
        //private void getChild(FunctionViewModel parent, List<FunctionViewModel> functions)
        //{
        //    parent.Childs = functions.Where(e => e.ParentId == parent.Id).ToList();
        //    parent.Childs.ForEach(e => getChild(e, functions));
        //}
        private List<TreeFunctionViewModel> getChildTree(List<FunctionViewModel> sources, string parentId = null)
        {
            var results = new List<TreeFunctionViewModel>();
            var parents = sources.Where(e => e.ParentId == parentId).OrderBy(e => e.SortOrder);
            foreach (var parent in parents)
            {
                var result = new TreeFunctionViewModel()
                {
                    Data = parent,
                    Children = getChildTree(sources, parent.Id)
                };
                result.Expanded = result.Children.Count > 0;
                results.Add(result);
            }
            return results;
        }
        public async Task<IEnumerable<FunctionViewModel>> GetFunctionsWithoutChildren(string textSearch)
        {
            var entities = await _repository.GetNoTrackingEntities().Where(e => e.ParentId == null && EF.Functions.Like(e.Name,$"%{textSearch}%")).OrderBy(e => e.SortOrder).ThenBy(e => e.Name).ToListAsync();
            var result = _mapper.Map<List<FunctionViewModel>>(entities);
            return result;
        }
    }
}
