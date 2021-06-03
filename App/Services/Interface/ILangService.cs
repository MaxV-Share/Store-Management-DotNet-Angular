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
    public interface ILangService : IBaseService<Lang, LangCR, LangVm, string>
    {
        Task<LangVm> CreateAsync(LangCR request);
        Task<LangVm> CreateAsync(List<LangCR> request);
        Task<T> UpdateAsync<T>(string id, LangVm request);
    }
}
