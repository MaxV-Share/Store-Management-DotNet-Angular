using App.DTOs;
using App.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ISaleService
    {
        public Task<SaleNonRequest> PostAsync(SaleRequest request);
    }
}
