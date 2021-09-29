using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.DTOs;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities;

namespace App.Services.Interface
{
    public interface IFunctionService : IBaseService<Function, FunctionCreateRequest, FunctionUpdateRequest, FunctionViewModel, string>
    {
        Task<IEnumerable<TreeFunctionViewModel>> GetTreeNodeAsync();
        Task<IEnumerable<FunctionViewModel>> GetTreeAsync();
        Task<IEnumerable<FunctionViewModel>> GetFunctionsWithoutChildren(string textSearch);
    }
}
