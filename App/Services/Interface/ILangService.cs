using App.Models.DTOs;
using App.Models.DTOs.CreateRequest;
using App.Models.Entities;
using App.Services.Base;
using MaxV.Helper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ILangService : IBaseService<Lang, LangCreateRequest, LangViewModel, string>
    {
        Task<LangViewModel> CreateAsync(LangCreateRequest request);
        Task<LangViewModel> CreateAsync(List<LangCreateRequest> request);
        Task<T> UpdateAsync<T>(string id, LangViewModel request);
    }
}
