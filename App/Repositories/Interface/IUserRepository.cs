using App.Models.Entities;
using App.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities.Identities;

namespace App.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync(string filter);
    }
}
