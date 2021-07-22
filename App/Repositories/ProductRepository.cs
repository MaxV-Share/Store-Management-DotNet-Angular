using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        {
        }
        public override async Task<Product> CreateAsync(Product entity)
        {
            var currentUser = await _userService.GetCurrentUser();
            entity.CreateBy = currentUser?.UserName;
            entity.SetDefaultValue();
            Entities.Add(entity);
            return entity;
        }
    }
}
