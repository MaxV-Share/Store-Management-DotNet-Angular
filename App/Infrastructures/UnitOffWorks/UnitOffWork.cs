using App.Infrastructures.Dbcontexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructures.UnitOffWorks
{
    public class UnitOffWork : IUnitOffWork
    {

        private readonly ApplicationDbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _tx { get; set; }
        public UnitOffWork(ApplicationDbContext context)
        {
            _context = context;
        }
        ~UnitOffWork()
        {
            Dispose(false);
        }

        private async Task BeginTransactionAsync()
        {
            _tx = await _context.Database.BeginTransactionAsync();
        }

        private async Task CommitTransactionAsync()
        {
            await _tx.CommitAsync();
            await ReleaseTransactionAsync();
        }

        private async Task RollbackTransactionAsync()
        {
            await _tx.RollbackAsync();
            await ReleaseTransactionAsync();
        }

        private async Task ReleaseTransactionAsync()
        {
            await _tx.DisposeAsync();
            _tx = null;
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _tx?.Dispose();
                _tx = null;
            }

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public async Task DoWorkWithTransaction(Action action)
        {
            using (var trans = await _context.Database.BeginTransactionAsync())
            {
                action.Invoke();
                await trans.CommitAsync();
            }
        }
    }
}
