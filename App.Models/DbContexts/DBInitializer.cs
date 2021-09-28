using App.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Models.Dbcontexts
{
    public class DBInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string AdminRoleName;
        public IConfiguration _configuration { get; }

        public DBInitializer(ApplicationDbContext context,
          UserManager<User> userManager,
          RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            AdminRoleName = _configuration.GetValue<string>("AdminRoleName");
        }

        public async Task Seed()
        {

            using (var transaction = new CommittableTransaction(new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead, Timeout = TimeSpan.FromMinutes(1) }))
            {
                #region Role
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole
                    {
                        Id = AdminRoleName,
                        Name = AdminRoleName,
                        NormalizedName = AdminRoleName.ToUpper(),
                    });
                }

                #endregion Role

                #region User

                if (!_userManager.Users.Any())
                {
                    var result = await _userManager.CreateAsync(new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "admin",
                        FullName = "Quản trị",
                        Email = "admin@admin.com",
                        LockoutEnabled = false
                    }, "Admin@123");
                    if (result.Succeeded)
                    {

                        var user = await _userManager.FindByNameAsync("admin");
                        await _userManager.AddToRoleAsync(user, AdminRoleName);
                    }
                }
                #endregion User

                #region Lang
                if(!_context.Langs.Any())
                {
                    await _context.Langs.AddAsync(new Lang
                    {
                        Id = "vi",
                        Name = "Tiếng việt",
                        Order = 1,
                        Uuid = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        CreateBy = "Seed"
                    });
                    await _context.Langs.AddAsync(new Lang
                    {
                        Id = "en",
                        Name = "English",
                        Order = 2,
                        Uuid = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        CreateBy = "Seed"
                    });
                    await _context.SaveChangesAsync();
                }
                #endregion
                await _context.SaveChangesAsync();
                transaction.Commit();
            }


        }
    }
}