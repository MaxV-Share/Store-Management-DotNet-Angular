using App.DTOs;
using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using MaxV.Helper.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class LangService : BaseService<Lang, LangCreateRequest, LangUpdateRequest, LangViewModel, string>, ILangService
    {
        public LangService( IMapper mapper, IUnitOffWork unitOffWork, ILogger<LangService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}
