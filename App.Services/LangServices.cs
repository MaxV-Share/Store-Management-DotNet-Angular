using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using App.Models.DTOs.Langs;
using App.Models.DTOs.PagingViewModels;
using System.Threading.Tasks;
using App.EFCore;
using App.Common.Extensions;
using System.Linq;
using System;
using MaxV.Common.Model;

namespace App.Services
{
    public class LangService : BaseService<Lang, LangCreateRequest, LangUpdateRequest, LangViewModel, string>, ILangService
    {
        public LangService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<LangService> logger) : base(mapper, unitOffWork, logger)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IBasePaging<LangViewModel>> GetPagingAsync(LangFilterRequest request)
        {
            var query = _unitOffWork.LangRepository.GetNoTrackingEntities().ToLangViewModel();
            if (!request.SearchValue.IsNullOrEmpty())
            {
                query = query.Where(e => e.Name.Contains(request.SearchValue));
            }
            var result = await query.ToPagingAsync(request);

            return result;
        }
    }
}
