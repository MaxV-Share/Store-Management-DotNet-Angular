using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Threading.Tasks;
using App.Common.Model.DTOs;
using App.Common.Model;

namespace App.Services.Interface
{
    public interface ICommandInFunctionService : IBaseService<CommandInFunction, CommandInFunctionCreateRequest, CommandInFunctionUpdateRequest, CommandInFunctionViewModel, Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<BasePaging<CommandInFunctionViewModel>> GetPagingAsync(FilterBodyRequest request);
    }
}
