using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;

namespace App.Services.Interface
{
    public interface ILangService : IBaseService<Lang, LangCreateRequest, LangUpdateRequest, LangViewModel, string>
    {
    }
}
