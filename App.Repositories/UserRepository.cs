using App.Models.Entities.Identities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace App.Repositories.Interface
{

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IQueryable<User> GetAll(string filter)
        {
            var result = _userManager.Users.Where(e => e.UserName.Contains(filter) || e.PhoneNumber.Contains(filter));
            return result;
        }
    }
}
