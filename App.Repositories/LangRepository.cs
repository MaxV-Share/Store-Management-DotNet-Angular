using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class LangRepository : BaseRepository<Lang, string>, ILangRepository
    {
        public LangRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
