using App.Models.DTOs.CreateRequests;
using App.Models.DTOs;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities;
using App.Models.DTOs.UpdateRquests;

namespace App.Services.Interface
{
    public interface ICommandService : IBaseService<Command, CommandCreateRequest, CommandUpdateRequest, CommandViewModel, string>
    {
    }
}
