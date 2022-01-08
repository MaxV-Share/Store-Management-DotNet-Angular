using App.Models.Entities.Identities;
using App.Models.Mapper;
using App.Repositories.Extenstions;
using App.Repositories.UnitOffWorks;
using App.Services.Extenstions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using App.Models.DbContexts;

namespace App.Infrastructures.Startups.ServicesExtensions
{
    public static class InjectionServiceExtension
    {
        public static void AddInjectedServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddRepositories();
            services.AddTransient<DBInitializer>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<IUnitOffWork, UnitOffWork>();
            services.AddServices();
        }
    }
}