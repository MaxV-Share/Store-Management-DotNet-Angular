using App.Models.Entities.Identities;
using App.Repositories.BaseRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using App.Common.Model;
using System.Collections.Generic;

namespace App.Repositories.UnitOffWorks
{
    public interface IUnitOffWork //: IDisposable
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();
        Task DoWorkWithTransaction(Action action);
        Task<IEnumerable<TResult>> QueryAsync<TResult>(string query);
        IBaseRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        UserManager<User> UserManager { get; }
    }
}