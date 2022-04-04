using App.Common.Extensions;
using App.Common.Model;
using App.Common.Model.DTOs;
using App.EFCore;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.DTOs.Functions;
using System;

namespace App.Services
{
    public class FunctionService : BaseService<Function, FunctionCreateRequest, FunctionUpdateRequest, FunctionFullViewModel, string>, IFunctionService
    {
        private readonly FunctionDetailService _functionDetailService;
        public FunctionService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<FunctionService> logger, FunctionDetailService functionDetailService) : base(mapper, unitOffWork, logger)
        {
            _functionDetailService = functionDetailService;
        }

        public override async Task<FunctionFullViewModel> GetByIdAsync(string id)
        {
            //var entity = await.GetByIdNoTrackingAsync(id, e => e.Detail);
            var result = await _mapper.ProjectTo<FunctionFullViewModel>(_unitOffWork.Repository<Function, string>().GetNoTrackingEntities()).SingleOrDefaultAsync(e => e.Id == id);
            return result;
        }
        public override async Task<IEnumerable<FunctionFullViewModel>> GetAllDTOAsync()
        {
            var query = _unitOffWork.Repository<Function, string>()
                                    .GetNoTrackingEntities()
                                    .OrderBy(e => e.ParentId)
                                    .ThenBy(e => e.SortOrder);
            var functions = await _mapper.ProjectTo<FunctionFullViewModel>(query).ToListAsync();
            return functions;
        }
        public async Task<IEnumerable<FunctionViewModel>> GetTreeAsync()
        {
            var query = _unitOffWork.Repository<Function, string>()
                                    .GetNoTrackingEntities()
                                    .Include(e => e.Childrens)
                                    .Where(e => e.ParentId == null)
                                    .OrderBy(e => e.ParentId)
                                    .ThenBy(e => e.SortOrder);

            var result = await _mapper.ProjectTo<FunctionViewModel>(query).ToListAsync();
            return result;
        }
        public async Task<IEnumerable<TreeFunctionViewModel>> GetTreeNodeAsync()
        {
            var query = _unitOffWork.Repository<Function, string>()
                                    .GetNoTrackingEntities()
                                    .OrderBy(e => e.ParentId)
                                    .ThenBy(e => e.SortOrder);

            var functions = await _mapper.ProjectTo<FunctionViewModel>(query).ToListAsync();

            var result = functions.ToNodeChildTree();
            return result;
        }
        public async Task<IEnumerable<FunctionViewModel>> GetFunctionsWithoutChildren(string textSearch)
        {
            var result = await _mapper.ProjectTo<FunctionViewModel>(_unitOffWork.Repository<Function, string>().GetNoTrackingEntities())
                                    .Where(e => e.ParentId == null && EF.Functions.Like(e.Name, $"%{textSearch}%"))
                                    .OrderBy(e => e.SortOrder)
                                    .ThenBy(e => e.Name)
                                    .ToListAsync();
            return result;
        }

        public async Task<IBasePaging<FunctionFullViewModel>> GetPagingAsync(IFilterBodyRequest request)
        {
            var queryEntities = _unitOffWork.Repository<Function, string>()
                                            .GetNoTrackingEntities()
                                            .OrderBy(e => e.Parent.SortOrder)
                                            .ThenBy(e => e.SortOrder);
            var query = _mapper.ProjectTo<FunctionFullViewModel>(queryEntities);

            if (!request.SearchValue.IsNullOrEmpty())
            {
                // query = query.Where(e => e.Name.Contains(request.SearchValue));
            }

            return await query.ToPagingAsync(request);
        }
        public override async Task<FunctionFullViewModel> CreateAsync(FunctionCreateRequest request) => await _unitOffWork.DoWorkWithTransaction(async () =>
        {
            var function = new Function();
            _mapper.Map(request, function);
            var effectedCount = await _unitOffWork.Repository<Function, string>().CreateAsync(function);
            request.Detail.ForEach(e =>
            {
                e.FunctionId = function.Id;
            });
            var functionDetails = _mapper.Map<List<FunctionDetail>>(request.Detail);
            effectedCount += await _unitOffWork.Repository<FunctionDetail, int>().CreateAsync(functionDetails);
            if (effectedCount <= 0)
            {
                throw new NullReferenceException();
            }
            var result = _mapper.Map<FunctionFullViewModel>(function);

            return result;
        });
        public override async Task<int> UpdateAsync(string id, FunctionUpdateRequest request) => await _unitOffWork.DoWorkWithTransaction(async () =>
        {
            var function = new Function();
            _mapper.Map(request, function);
            var effectedCount = await _unitOffWork.Repository<Function, string>().UpdateAsync(function);

            var functionDetailsNew = _mapper.Map<List<FunctionDetail>>(request.Detail.Where(e => !string.IsNullOrWhiteSpace(e.FunctionId)));
            var functionDetailsUpdate = _mapper.Map<List<FunctionDetail>>(request.Detail.Where(e => string.IsNullOrWhiteSpace(e.FunctionId)));
            if (functionDetailsNew.Any())
            {
                effectedCount += await _unitOffWork.Repository<FunctionDetail, int>().CreateAsync(functionDetailsNew);
            }

            if (functionDetailsUpdate.Any())
            {
                effectedCount += await _unitOffWork.Repository<FunctionDetail, int>().UpdateAsync(functionDetailsUpdate);
            }
            return effectedCount;
        });
    }
}