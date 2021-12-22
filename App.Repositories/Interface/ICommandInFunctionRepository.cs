using App.Models.Entities;
using App.Repositories.BaseRepository;
using System;

namespace App.Repositories.Interface
{
    public interface ICommandInFunctionRepository : IBaseRepository<CommandInFunction, Guid>
    {
    }
}