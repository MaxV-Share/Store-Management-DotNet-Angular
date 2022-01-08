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

namespace App.Services
{
    public class FunctionService : BaseService<Function, FunctionCreateRequest, FunctionUpdateRequest, FunctionViewModel, string>, IFunctionService
    {
        public FunctionService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<FunctionService> logger) : base(mapper, unitOffWork, logger)
        {
        }
        public override async Task<IEnumerable<FunctionViewModel>> GetAllDTOAsync()
        {
            var query = _unitOffWork.Repository<Function, string>()
                                    .GetNoTrackingEntities()
                                    .OrderBy(e => e.ParentId)
                                    .ThenBy(e => e.SortOrder);
            var functions = await _mapper.ProjectTo<FunctionViewModel>(query).ToListAsync();
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
            var query = _unitOffWork.Repository<Function, string>()
                                    .GetNoTrackingEntities()
                                    .Where(e => e.ParentId == null && EF.Functions.Like(e.Name, $"%{textSearch}%"))
                                    .OrderBy(e => e.SortOrder)
                                    .ThenBy(e => e.Name);

            var result = await _mapper.ProjectTo<FunctionViewModel>(query).ToListAsync();
            return result;
        }

        public async Task<IBasePaging<FunctionViewModel>> GetPagingAsync(IFilterBodyRequest request)
        {
            var queryEntities = _unitOffWork.Repository<Function, string>()
                                            .GetNoTrackingEntities()
                                            .OrderBy(e => e.ParentId)
                                            .ThenBy(e => e.SortOrder);
            var query = _mapper.ProjectTo<FunctionViewModel>(queryEntities);

            if (!request.SearchValue.IsNullOrEmpty())
            {
                query = query.Where(e => e.Name.Contains(request.SearchValue));
            }

            return await query.ToPagingAsync(request);
        }
    }
}
