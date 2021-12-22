using App.Models.Dbcontexts;
using App.Models.Entities.Identities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Dapper;
using MaxV.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Repositories.UnitOffWorks
{
    public class UnitOffWork : IUnitOffWork
    {

        private readonly ApplicationDbContext _dbContext;
        private bool _disposed = false;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction _tx { get; set; }
        private IBillRepository _billRepository;
        private IBillDetailRepository _billDetailRepository;
        private ICategoryDetailRepository _categoryDetailRepository;
        private ICategoryRepository _categoryRepository;
        private ICommandInFunctionRepository _commandInFunctionRepository;
        private ICommandRepository _commandRepository;
        private ICustomerRepository _customerRepository;
        private IDiscountRepository _discountRepository;
        private IFunctionRepository _functionRepository;
        private ILangRepository _langRepository;
        private IPermissionRepository _permissionRepository;
        private IProductDetailRepository _productDetailRepository;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private UserManager<User> _userManager;
        public UnitOffWork(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _dbContext = context;
            _serviceProvider = serviceProvider;
        }

        ~UnitOffWork()
        {
            Dispose(false);
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
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
        public async Task DoWorkWithTransaction(Action action)
        {
            using (var trans = await _dbContext.Database.BeginTransactionAsync())
            {
                action.Invoke();
                await trans.CommitAsync();
            }
        }
        public async Task<IEnumerable<TResult>> OpenConnection<TResult>(string query)
        {
            IEnumerable<TResult> result;
            using (var connection = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString))
            {
                connection.Open();

                result = await connection.QueryAsync<TResult>(query);
            }
            return result;
        }

        public IBaseRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            return _serviceProvider.GetService<IBaseRepository<TEntity, TKey>>();
        }

        public IBillDetailRepository BillDetailRepository
        {
            get
            {

                if (_billDetailRepository == null)
                {
                    _billDetailRepository = _serviceProvider.GetService<IBillDetailRepository>();
                }
                return _billDetailRepository;
            }
        }
        public IBillRepository BillRepository
        {
            get
            {

                if (_billRepository == null)
                {
                    _billRepository = _serviceProvider.GetService<IBillRepository>();
                }
                return _billRepository;
            }
        }

        public ICategoryDetailRepository CategoryDetailRepository
        {
            get
            {

                if (_categoryDetailRepository == null)
                {
                    _categoryDetailRepository = _serviceProvider.GetService<ICategoryDetailRepository>();
                }
                return _categoryDetailRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {

                if (_categoryRepository == null)
                {
                    _categoryRepository = _serviceProvider.GetService<ICategoryRepository>();
                }
                return _categoryRepository;
            }
        }

        public ICommandInFunctionRepository CommandInFunctionRepository
        {
            get
            {

                if (_commandInFunctionRepository == null)
                {
                    _commandInFunctionRepository = _serviceProvider.GetService<ICommandInFunctionRepository>();
                }
                return _commandInFunctionRepository;
            }
        }

        public ICommandRepository CommandRepository
        {
            get
            {

                if (_commandRepository == null)
                {
                    _commandRepository = _serviceProvider.GetService<ICommandRepository>();
                }
                return _commandRepository;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {

                if (_customerRepository == null)
                {
                    _customerRepository = _serviceProvider.GetService<ICustomerRepository>();
                }
                return _customerRepository;
            }
        }



        public IDiscountRepository DiscountRepository
        {
            get
            {

                if (_discountRepository == null)
                {
                    _discountRepository = _serviceProvider.GetService<IDiscountRepository>();
                }
                return _discountRepository;
            }
        }

        public IFunctionRepository FunctionRepository
        {
            get
            {

                if (_functionRepository == null)
                {
                    _functionRepository = _serviceProvider.GetService<IFunctionRepository>();
                }
                return _functionRepository;
            }
        }

        public ILangRepository LangRepository
        {
            get
            {

                if (_langRepository == null)
                {
                    _langRepository = _serviceProvider.GetService<ILangRepository>();
                }
                return _langRepository;
            }
        }

        public IPermissionRepository PermissionRepository
        {
            get
            {

                if (_permissionRepository == null)
                {
                    _permissionRepository = _serviceProvider.GetService<IPermissionRepository>();
                }
                return _permissionRepository;
            }
        }

        public IProductDetailRepository ProductDetailRepository
        {
            get
            {

                if (_productDetailRepository == null)
                {
                    _productDetailRepository = _serviceProvider.GetService<IProductDetailRepository>();
                }
                return _productDetailRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {

                if (_productRepository == null)
                {
                    _productRepository = _serviceProvider.GetService<IProductRepository>();
                }
                return _productRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = _serviceProvider.GetService<IUserRepository>();
                }
                return _userRepository;
            }
        }

        public UserManager<User> UserManager
        {
            get
            {

                if (_userManager == null)
                {
                    _userManager = _serviceProvider.GetService<UserManager<User>>();
                }
                return _userManager;
            }
        }
    }
}
