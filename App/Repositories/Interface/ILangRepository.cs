using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Interface
{
    public interface ILangRepository : IBaseRepository<Lang, string>
    {
    }
}
