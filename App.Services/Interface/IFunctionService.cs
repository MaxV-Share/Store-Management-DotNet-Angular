using App.Common.Model;
using App.Common.Model.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models.DTOs.Functions;

namespace App.Services.Interface
{
    public interface IFunctionService : IBaseService<Function, FunctionCreateRequest, FunctionUpdateRequest, FunctionFullViewModel, string>
    {
        Task<IEnumerable<TreeFunctionViewModel>> GetTreeNodeAsync();
        Task<IEnumerable<FunctionViewModel>> GetTreeAsync();
        //new Task<FunctionFullViewModel> GetByIdAsync(string id);
        Task<IEnumerable<FunctionViewModel>> GetFunctionsWithoutChildren(string textSearch);
        Task<IBasePaging<FunctionFullViewModel>> GetPagingAsync(IFilterBodyRequest request);
    }
}
