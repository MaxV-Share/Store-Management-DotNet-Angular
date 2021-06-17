using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class BillService : BaseService<Bill, BillCreateRequest, BillViewModel, int>, IBillService
    {
        public BillService(IBillRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public Task<BillViewModel> CreateAsync(BillCreateRequest request)
        {
            var newModel = new Bill()
            {

            };
            throw new NotImplementedException();
        }
    }
}
    