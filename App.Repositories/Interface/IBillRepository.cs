﻿using App.Models.Entities;
using App.Repositories.BaseRepository;

namespace App.Repositories.Interface
{
    public interface IBillRepository : IBaseRepository<Bill, int>
    {
    }
}