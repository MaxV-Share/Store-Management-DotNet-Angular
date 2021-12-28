using App.Models.Entities.Identities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using App.Common.Model;

namespace App.Repositories.UnitOffWorks
{
    public interface IUnitOffWork //: IDisposable
    {
        Task<int> SaveChangesAsync();

        int SaveChanges();

        Task DoWorkWithTransaction(Action action);

        IBaseRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;

        IBillDetailRepository BillDetailRepository { get; }
        IBillRepository BillRepository { get; }
        ICategoryDetailRepository CategoryDetailRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICommandInFunctionRepository CommandInFunctionRepository { get; }
        ICommandRepository CommandRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IFunctionRepository FunctionRepository { get; }
        ILangRepository LangRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IProductDetailRepository ProductDetailRepository { get; }
        IProductRepository ProductRepository { get; }
        IUserRepository UserRepository { get; }
        UserManager<User> UserManager { get; }
    }
}