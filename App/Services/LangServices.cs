using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequest;
using App.Models.Entities;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using MaxV.Helper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class LangService : BaseService<Lang, LangCR, LangVm, string>, ILangService
    {
        public readonly ILangRepository _categoryRepository;
        public LangService(ILangRepository saleRepository, IMapper mapper) : base(saleRepository, mapper)
        {
            _categoryRepository = saleRepository;
        }

        public Task<LangVm> CreateAsync(LangCR request)
        {
            throw new NotImplementedException();
        }
        public Task<LangVm> CreateAsync(List<LangCR> request)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(string id, LangVm request)
        {
            throw new NotImplementedException();
        }
    }
}
