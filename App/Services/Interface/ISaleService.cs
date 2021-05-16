using App.DTOs;
using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ISaleService : IBaseService<Sale, SaleRequest, SaleNonRequest>
    {
        public Task<SaleNonRequest> PostAsync(SaleRequest request);  
    }
}
