using App.Models.DTOs.FunctionDetails;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class FunctionDetailService : BaseService<FunctionDetail, FunctionDetailCreateRequest, FunctionDetailUpdateRequest, FunctionDetailViewModel, int>, IFunctionDetailService
    {
        public FunctionDetailService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<FunctionDetailService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}
