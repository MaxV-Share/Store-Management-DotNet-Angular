using App.Common.Extensions;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Repositories.Extenstions
{
    public static class RepositoryExtenstions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddProxiedScoped<IBaseRepository<BillDetail, int>, BaseRepository<BillDetail, int>>();
            services.AddProxiedScoped<IBaseRepository<Bill, int>, BaseRepository<Bill, int>>();
            services.AddProxiedScoped<IBaseRepository<Category, int>, BaseRepository<Category, int>>();
            services.AddProxiedScoped<IBaseRepository<CategoryDetail, int>, BaseRepository<CategoryDetail, int>>();
            services.AddProxiedScoped<IBaseRepository<Command, string>, BaseRepository<Command, string>>();
            services.AddProxiedScoped<IBaseRepository<CommandInFunction, Guid>, BaseRepository<CommandInFunction, Guid>>();
            services.AddProxiedScoped<IBaseRepository<Customer, int>, BaseRepository<Customer, int>>();
            services.AddProxiedScoped<IBaseRepository<Discount, int>, BaseRepository<Discount, int>>();
            services.AddProxiedScoped<IBaseRepository<Function, string>, BaseRepository<Function, string>>();
            services.AddProxiedScoped<IBaseRepository<Lang, string>, BaseRepository<Lang, string>>();
            services.AddProxiedScoped<IBaseRepository<Product, int>, BaseRepository<Product, int>>();
            services.AddProxiedScoped<IBaseRepository<ProductDetail, int>, BaseRepository<ProductDetail, int>>();
        }
    }
}