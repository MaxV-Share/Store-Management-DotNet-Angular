using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructures.UnitOffWorks
{
    public interface IUnitOffWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task ReleaseTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
