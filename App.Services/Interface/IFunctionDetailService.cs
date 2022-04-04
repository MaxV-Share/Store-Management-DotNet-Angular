using App.Models.DTOs.FunctionDetails;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IFunctionDetailService : IBaseService<FunctionDetail, FunctionDetailCreateRequest, FunctionDetailUpdateRequest, FunctionDetailViewModel, int>
    {
    }
}
