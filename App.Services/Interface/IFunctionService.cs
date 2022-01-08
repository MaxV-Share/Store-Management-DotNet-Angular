using App.Common.Model;
using App.Common.Model.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IFunctionService : IBaseService<Function, FunctionCreateRequest, FunctionUpdateRequest, FunctionViewModel, string>
    {
        Task<IEnumerable<TreeFunctionViewModel>> GetTreeNodeAsync();
        Task<IEnumerable<FunctionViewModel>> GetTreeAsync();
        Task<IEnumerable<FunctionViewModel>> GetFunctionsWithoutChildren(string textSearch);
        Task<IBasePaging<FunctionViewModel>> GetPagingAsync(IFilterBodyRequest request);
    }
}
