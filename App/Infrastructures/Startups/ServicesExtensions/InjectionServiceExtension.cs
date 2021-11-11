using App.Models.Dbcontexts;
using App.Models.Entities.Identities;
using App.Models.Extensions;
using App.Models.Mapper;
using App.Repositories.Extenstions;
using App.Repositories.UnitOffWorks;
using App.Services.Extenstions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructures.Startups.ServicesExtensions
{
    public static class InjectionServiceExtension
    {
        public static void AddInjectedServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddTransient<DBInitializer>();
            services.AddScoped<IUnitOffWork, UnitOffWork>();
            services.AddScoped<UserManager<User>>();
            services.AddRepositories();
            services.AddServices();
        }
    }
}