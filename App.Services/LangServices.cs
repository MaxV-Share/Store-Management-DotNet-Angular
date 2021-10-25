using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace App.Services
{
    public class LangService : BaseService<Lang, LangCreateRequest, LangUpdateRequest, LangViewModel, string>, ILangService
    {
        public LangService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<LangService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}
