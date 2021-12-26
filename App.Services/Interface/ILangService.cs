using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using App.Models.DTOs.Langs;
using App.Models.DTOs.PagingViewModels;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ILangService : IBaseService<Lang, LangCreateRequest, LangUpdateRequest, LangViewModel, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IBasePaging<LangViewModel>> GetPagingAsync(LangFilterRequest request);
    }
}
